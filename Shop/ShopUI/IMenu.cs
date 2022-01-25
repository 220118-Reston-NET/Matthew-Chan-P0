namespace ShopUI
{
    /*
        Interface are one of the best way to implement abstraction
        Every method is implicity abstract meaning you don't have to write anything
        Every method is public
    */
    public interface IMenu{
        /// <summary>
        /// Will dispaly the menu and user vhoices in the terminal
        /// </summary>
        void Display();
        /// <summary>
        /// Will record the user's choice and change/route yoru menu based on that choice
        /// </summary>
        /// <returns> Return the menu that will hcange your screen
        string UserChoice();
    }
    
}