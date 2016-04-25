namespace Samples.WinRT.Client.ScreenObjects.Contracts
{
    public interface ILoginScreenObject
    {
        bool IsActive();
        void SetUsername(string username);
        void Login();
    }
}
