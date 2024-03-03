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
            #region продолжение или начало новой игры
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
                    return;
            }
            #endregion

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
            await _game.CreateAsync(game.ToGameDB());
            Console.WriteLine("Выбор сохранен. Введите число");
            // проверка ответа

            // окончание игры

            // предложить варианты (меню)
        }

        private static void WriteSettingsText()
        {
            Console.WriteLine("Выберите уровень сложности. Введите одну цифру");
            Console.WriteLine("1 - Простая. Угадываем с 1 до 10.");
            Console.WriteLine("2 - Средняя. Угадываем с 1 до 100. Количество попыток - 50");
            Console.WriteLine("3 - Сложная. Угадываем с 1 до 1 000. Количество попыток - 100");
            Console.WriteLine("4 - Камикадзе. Угадываем с 1 до 1 000 000 000. Количество попыток - 3");
        }
    }
}
