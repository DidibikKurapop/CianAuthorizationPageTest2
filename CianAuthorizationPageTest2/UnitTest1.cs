
using OpenQA.Selenium;
namespace CianAuthorizationPageTest2
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _signInButton = By.XPath("//span[text()='Войти']");
        private readonly By _switchToEmailAuthBtn = By.XPath("//button[@data-name='SwitchToEmailAuthBtn']");
        private readonly By _inputUsername = By.XPath("//input[@name='username']");
        private readonly By _continueAuthBtn = By.XPath("//button[@data-name='ContinueAuthBtn']");
        private readonly By _inputPassword = By.XPath("//input[@name='password']");
        private readonly By _actualLogin = By.XPath("//div[@class='_25d45facb5--user-name--oMFPn']");
        private readonly By _userPage = By.XPath("//a[@data-name='UserAvatar']");

        private const string _email = "asqwasqeqq@gmail.com";
        private const string _password = "xZkyy5YJsBJPGvi";
        private const string _expectedLogin = "ID 102229454";


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://tolyatti.cian.ru/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();

            Thread.Sleep(400);
            var switchToEmailAuthBtn = driver.FindElement(_switchToEmailAuthBtn);
            switchToEmailAuthBtn.Click();

            var inputUsername = driver.FindElement(_inputUsername);
            inputUsername.SendKeys(_email);

            var continueAuthBtn = driver.FindElement(_continueAuthBtn);
            continueAuthBtn.Click();

            Thread.Sleep(400);
            var inputPassword = driver.FindElement(_inputPassword);
            inputPassword.SendKeys(_password);

            Thread.Sleep(400);
            continueAuthBtn.Click();

            Thread.Sleep(1500);

            var userPage = driver.FindElement(_userPage);
            userPage.Click();

            Thread.Sleep(400);
            var actualLogin = driver.FindElement(_actualLogin).Text;
            Assert.AreEqual(_expectedLogin, actualLogin, "login is not correct or authorization was not completed");
            

        }
        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
        }
    }
}