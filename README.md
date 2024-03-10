Игра "Угадай число"
Принцип
Single responsibility principle (SRP) реализован с помощью разделения на классы Game, User,Setting, которые четко разделены на свои обязанности.
Open/Close principle - релизован с помощью наследования сервиса GameService и его произвольного класса FastGameService.
Liskov Substitution Principle (LSP) учтен, если заменить FastGameService на GameService через интерфейс IGameService, приложение будет полноценно работать.
Interface Segregation Principle (ISP) - все сервисы взаимодействуют через свои интерфейсы.
Dependency inversion principle (DIP) - на вход принимаются абстракции, а не скрвисы напрямую.
