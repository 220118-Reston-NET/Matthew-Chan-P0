using ShopUI;

bool repeat = true;
IMenu menu = new MainMenu();

while(repeat){
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();
    
}
