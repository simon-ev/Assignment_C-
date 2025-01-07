
using MainApp.Dialogs;
using Library.Interfaces;
using Library.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IFileService>(new FileService("Data", "users.json"))
    .AddSingleton<IUserService, UserService>()
    .AddSingleton<MenuDialog>()
    .BuildServiceProvider();

var menuDialog = serviceProvider.GetRequiredService<MenuDialog>();
menuDialog.MainMenu();
    