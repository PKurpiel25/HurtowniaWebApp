using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace HurtowniaWebClientTesty
{
    public class ChromeTesty
    {
        IWebDriver _driver = null!;

        [SetUp]
        public void StartBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver
            {
                Url = "https://localhost:7204"
            };
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        [Test]
        public void RejestracjaTest()
        {
            Testy.RejestracjaTest(_driver);
        }

        [Test]
        public void LoginTest()
        {
            Testy.LoginTest(_driver);
        }

        [Test]
        public void ZłóżZamówienieTest()
        {
            Testy.ZłóżZamówienieTest(_driver);
        }

        [Test]
        public void DodajProduktTest()
        {
            Testy.DodajProduktTest(_driver);
        }

        [Test]
        public void WyślijZapytanieTest()
        {
            Testy.WyślijZapytanieTest(_driver);
        }

        [Test]
        public void UpdateProduktTest()
        {
            Testy.UpdateProduktTest(_driver);
        }

        [Test]
        public void UsuńProduktTest()
        {
            Testy.UsuńProduktTest(_driver);
        }

        [Test]
        public void UpdateKontoTest()
        {
            Testy.UpdateKontoTest(_driver);
        }

        [Test]
        public void UpdateHasłoTest()
        {
            Testy.UpdateHasłoTest(_driver);
        }

        [Test]
        public void DodajKontoTest()
        {
            Testy.DodajKontoTest(_driver);
        }

        [Test]
        public void UsuńKontoTest()
        {
            Testy.UsuńKontoTest(_driver);
        }

    }
}
