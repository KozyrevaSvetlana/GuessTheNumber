using GuessTheNumberConsoleApp.Services.Interfaces;
using Services.Abstractions;
using Services.Contracts;
using Services.Contracts.Helpers;

namespace GuessTheNumberConsoleApp.Services.Models
{
    public class Application : IApplication
    {
        private readonly IGameService _game;
        private readonly IUserService _userService;
        private readonly ISettingService _settingService;
        private readonly IValidation _validation;
        public Application(IGameService gameService, IUserService userService, ISettingService settingService, IValidation validation)
        {
            _game = gameService;
            _userService = userService;
            _settingService = settingService;
            _validation = validation;
        }

        public async Task RunAsync()
        {
            #region получение пользователя и валидация
            Console.WriteLine("Здравствуйте. Как Вас зовут?");
            var input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || !_validation.IsValidName(input))
            {
                Console.WriteLine("Имя не корректно. Можно использовать только Кириллицу и цифры. Напишите свое имя еще раз");
                input = Console.ReadLine();
            }
            #endregion
            #region сохранение/получение пользователя бд
            if (!await _userService.ContainsAsync(input))
            {
                await _userService.CreateAsync(input.ToUserDB());
            }
            var userDB = await _userService.GetByNameAsync(input);
            var user = userDB.ToUserDTO();
            #endregion
            #region продолжение последней игры
            if (await _game.AnyInProcessAsync(user.Name))
            {
                Console.WriteLine("Хотите продолжить последнюю игру?");
                input = Console.ReadLine();
                while (string.IsNullOrEmpty(input) || !_validation.IsValidAnswer(input.Trim().ToLower()))
                {
                    Console.WriteLine("Ответ не ясен. Так хотите продолжить последнюю игру?");
                    input = Console.ReadLine();
                }

                if (_validation.IsNegativeAnswer(input))
                {

                }
            }
            #endregion
            #region начало новой игры
            // новая игра
            WriteSettingsText();
            input = Console.ReadLine();
            var options = new List<string>() { "1", "2", "3", "4" };
            while (string.IsNullOrEmpty(input) || !_validation.IsValidHandleAnswer(options, input.Trim().ToLower()))
            {
                WriteSettingsText();
                input = Console.ReadLine();
            }
            var selectedSetting = (DifficultyLevelEnum)Enum.Parse(typeof(DifficultyLevelEnum), input, true);
            var setting = new SettingDTO(selectedSetting);
            var game = new GameDTO(user, setting);
            var gameId = await _game.CreateAsync(game.ToGameDB());
            #endregion
            #region проверка ответа
            Console.WriteLine("Выбор сохранен");
            var estimatedNumber = await WriteGuessNumber(setting.Since, setting.For, gameId);
            while (!await _game.IsSameNumber(gameId, estimatedNumber))
            {
                estimatedNumber = await WriteGuessNumber(setting.Since, setting.For, gameId);
            }
            #endregion
            #region окончание игры
            await _game.ChangeStatus(gameId, (int)StatusEnum.Finished);
            var gameDB = await _game.Get(gameId);
            Console.WriteLine($"Поздравляем! Игра осончена. Вы угадали число {game.HiddenNumber}! Количество попыток - {gameDB.CurrentAttempt}");
            #endregion
        }

        private static void WriteSettingsText()
        {
            Console.WriteLine("Выберите уровень сложности. Введите одну цифру");
            Console.WriteLine("1 - Простая. Угадываем с 1 до 10.");
            Console.WriteLine("2 - Средняя. Угадываем с 1 до 100. Количество попыток - 50");
            Console.WriteLine("3 - Сложная. Угадываем с 1 до 1 000. Количество попыток - 100");
            Console.WriteLine("4 - Камикадзе. Угадываем с 1 до 1 000 000 000. Количество попыток - 3");
        }
        private async Task<int> WriteGuessNumber(int start, int end, int gameId)
        {
            Console.WriteLine($"Напиши число {start} от до {end}");
            var input = Console.ReadLine();
            int estimatedNumber = -1;
            while (string.IsNullOrEmpty(input) || !Int32.TryParse(input, out estimatedNumber))
            {
                await WriteGuessNumber(start, end, gameId);
            }
            return estimatedNumber;
        }
    }
}
