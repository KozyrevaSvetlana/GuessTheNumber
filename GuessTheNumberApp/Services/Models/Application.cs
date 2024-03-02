using Domain.Entities;
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
            Console.WriteLine("Здравствуйте. Как Вас зовут?");
            var input = Console.ReadLine();
            while (!_validation.IsValidName(input))
            {
                Console.WriteLine("Имя не корректно. Можно использовать только Кириллицу и цифры. Напишите свое имя еще раз");
                input = Console.ReadLine();
            }

            UserDTO? user = null;
            User? userDB = null;
            if (!await _userService.ContainsUserAsync(input))
            {
                userDB = await _userService.GetByUserNameAsync(input);
            }
            else
            {
                userDB = await _userService.GetByUserNameAsync(input);
            }
            user = userDB.ToUserDTO();
            Console.WriteLine($"{user.Name}");
            Console.ReadLine();
            // вход

            // начало игры

            // продолжение игры

            // проверка ответа

            // окончание игры

            // предложить варианты (меню)
        }


        public Task CreateUser()
        {
            throw new NotImplementedException();
        }

        public Task GetUserByName(string username)
        {
            throw new NotImplementedException();
        }

    }
}
