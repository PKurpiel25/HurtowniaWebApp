using NUnit.Framework;
using OpenQA.Selenium;

namespace HurtowniaWebClientTesty
{
    public static class Testy
    {
        public static void RejestracjaTest(IWebDriver driver)
        {
            var login = "ANowak";
            var email = "anowak@gmail.com";
            var hasło = "Asd34%";
            var imię = "Anna";
            var nazw = "Nowak";
            var firma = "Testowa Hurtownia";
            var nrTel = "555623081";
            var pesel = "93417625857";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(email);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[3]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[4]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[5]/input")).SendKeys(imię);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[6]/input")).SendKeys(nazw);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[7]/input")).SendKeys(firma);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[8]/input")).SendKeys(nrTel);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[9]/input")).SendKeys(pesel);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            Thread.Sleep(100);

            Assert.AreEqual("Strona główna - Hurtownia", driver.Title);
        }

        public static void LoginTest(IWebDriver driver)
        {
            var login = "PKowal";
            var hasło = "Zaq12#";
            var pamiętaj = false;

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            if (pamiętaj) 
            {
                driver.FindElement(By.XPath("/html/body/div/main/form/div[3]/input")).Click();
            }
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();

            Assert.AreEqual("Strona główna - Hurtownia", driver.Title);
        }

        public static void ZłóżZamówienieTest(IWebDriver driver)
        {
            var login = "ANowak";
            var hasło = "Asd34%";
            var ulica = "Marszałkowska 30";
            var miasto = "Warszawa";
            var kod = "05-782";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/table/tbody/tr[1]/td[1]/form/button")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/aside/form/button")).Click();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/ul/li[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/a")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[3]/input")).SendKeys(ulica);
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[4]/input")).SendKeys(miasto);
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[5]/input")).SendKeys(kod);
            driver.FindElement(By.XPath("/html/body/div/main/div/form/button")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/button")).Submit();
        }

        public static void DodajProduktTest(IWebDriver driver)
        {
            var login = "MCiszew";
            var hasło = "Jkl45^";
            var nazwa = "Telewizor Samsung QLED QE55Q60AAU - 55\" - 4K - Smart TV";
            var opis = "Telewizor LG 65QNED813QA zachwyci cię głębią kolorów i płynnością działania. Doskonała jakość obrazu to zasługa m.in. technologii Quantum Dot + NanoCell oraz szybkiego procesora α7 AI. Gracze docenią bogatą bibliotekę gier w chmurze, a ThinQ AI oraz system webOS dopasują dla ciebie treści. Ciesz się szczegółowym obrazem z dużą liczbą detali w rozdzielczości 4K Zachwyć się głębią kolorów dzięki technologiom Quantum Dot + NanoCell Doskonałe wrażenia wizualne zapewnia szybki procesor α7 AI Personalizację ustawień urządzenia ułatwią ci sztuczna inteligencja i system webOS Graj w gry, oglądaj filmy i seriale albo korzystaj z biblioteki muzycznej jednej z wielu platform streamingowych Poznaj telewizor LG 65QNED813QA Niesamowite kolory Poczuj magię kolorów dzięki zastosowanym w LG 65QNED813QA technologiom. LG QNED, czyli Quantum Nano-Emitting Diodes, oraz Quantum Dot i NanoCell pozwalają wygaszać strefy ekranu, żeby nadać kolorom większą głębię i niesamowite nasycenie barw, minimalizując przy tym efekt halo. Obrazy są czyste, a kolory niezwykle wyraziste – dzięki temu doświadczysz ich prawdziwej ostrości. I to w 4K! Procesor α7 Szybki procesor α7 oraz sztuczna inteligencja zadbają o dostarczanie niezwykłych wrażeń wizualnych. Na pewno docenisz optymalizację treści, za którą odpowiedzialne są algorytmy przystosowane do głębokiego uczenia się. Tak działa ten innowacyjny czip, który umożliwia automatyczne dostosowanie zarówno dźwięku, jak i obrazu. LG 65QNED813QA zadba o każdy szczegół, żeby zapewnić ci rozrywkę na najwyższym poziomie technologicznym. Technologia Smart Urządzenie pozwala łatwo docierać do ulubionych aplikacji czy dopasowanych do twoich upodobań powiadomień. Zastanawiasz się, jak to możliwie? Wszystko dzięki sztucznej inteligencji ThinQ AI oraz systemowi webOS, które personalizują i dobierają treści do użytkownika. Steruj urządzeniem szybko i korzystaj z dobranych do ciebie rekomendacji – na tym polega prawdziwa technologia Smart w telewizorze LG 65QNED813QA. Granie bez ograniczeń Co powiesz na łatwy dostęp do niezliczonej ilości gier? Taką możliwość zyskujesz dzięki usłudze GEFORCE Now w telewizorze LG. Najnowsze tytuły będą w twoim zasięgu bez konieczności kupowania konsoli. To dopiero jest Cloud Gaming na wysokim poziomie! Technologia AMD FreeSync Premium Jeszcze jednym istotnym udoskonaleniem dla graczy jest technologia AMD FreeSync Premium, którą ma telewizor LG 65QNED813QA. To ona powoduje, że rozgrywki odbywają się płynnie, bez zbędnych przestojów i zacięć. Każdy fan gamingu na pewno doceni to rozwiązanie i zwiększy swoje szanse na zwycięstwo w każdej misji.";
            var cena = 3413.821M;
            var vat = 0.23M;
            var ilość = 100;
            var zdjęcie = "C:\\Users\\margo\\OneDrive - Warszawska Wyższa Szkoła Informatyki\\HurtowniaWebClient\\HurtowniaWebClientTesty\\Granny_Smith_Apples.jpg";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/a")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[1]/input")).SendKeys(nazwa);
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[2]/textarea")).SendKeys(opis);
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[3]/input")).SendKeys(cena.ToString());
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[4]/input")).SendKeys(vat.ToString());
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[5]/input")).SendKeys(ilość.ToString());
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div[6]/input")).SendKeys(zdjęcie);
            driver.FindElement(By.XPath("/html/body/div/main/div/form/input")).Submit();
            Thread.Sleep(100);

            Assert.AreEqual("Lista produktów - Hurtownia", driver.Title);
        }

        public static void WyślijZapytanieTest(IWebDriver driver)
        {
            var login = "ANowak";
            var hasło = "Asd34%";
            var tytuł = "Kiedy ten telewizor będzie znowu dostępny?";
            var treść = "Lorem ipsum docet";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/table/tbody/tr[1]/td[1]/form/button")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/aside/a")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/input")).SendKeys(tytuł);
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[2]/textarea")).SendKeys(treść);
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/input")).Submit();
            Thread.Sleep(100);

            Assert.AreEqual("Lista produktów - Hurtownia", driver.Title);
        }

        public static void UpdateProduktTest(IWebDriver driver)
        {
            var login = "MCiszew";
            var hasło = "Jkl45^";
            var nazwa = "UpdateTest";
            var opis = "Docet lorem";
            var cena = 37.00M;
            var vat = 0.10M;
            var ilość = 26;
            var zdjęcie = "C:\\Users\\margo\\OneDrive - Warszawska Wyższa Szkoła Informatyki\\HurtowniaWebClient\\HurtowniaWebClientTesty\\Granny_Smith_Apples.jpg";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/table/tbody/tr[1]/td[2]/a")).Click();
            var input1 = driver.FindElement(By.XPath("/html/body/div/main/div/form[2]/div[1]/input"));
            input1.Clear();
            input1.SendKeys(nazwa);
            var input2 = driver.FindElement(By.XPath("/html/body/div/main/div/form[2]/div[2]/textarea"));
            input2.Clear();
            input2.SendKeys(opis);
            var input3 = driver.FindElement(By.XPath("/html/body/div/main/div/form[2]/div[3]/input"));
            input3.Clear();
            input3.SendKeys(cena.ToString());
            var input4 = driver.FindElement(By.XPath("/html/body/div/main/div/form[2]/div[4]/input"));
            input4.Clear();
            input4.SendKeys(vat.ToString());
            var input5 = driver.FindElement(By.XPath("/html/body/div/main/div/form[2]/div[5]/input"));
            input5.Clear();
            input5.SendKeys(ilość.ToString());
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(100);
            driver.FindElement(By.XPath("/html/body/div/main/div/form[2]/div[6]/div/img[1]")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.XPath("/html/body/div/main/div/form[2]/div[7]/input")).SendKeys(zdjęcie);
            Thread.Sleep(100);
            driver.FindElement(By.XPath("/html/body/div/main/div/form[2]/button[@type='submit']")).Submit();

            Assert.AreEqual("Lista produktów - Hurtownia", driver.Title);
        }

        public static void UsuńProduktTest(IWebDriver driver)
        {
            var login = "MCiszew";
            var hasło = "Jkl45^";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/table/tbody/tr[1]/td[2]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/form[1]/button")).Submit();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(100);

            Assert.AreEqual("Lista produktów - Hurtownia", driver.Title);
        }

        public static void UpdateKontoTest(IWebDriver driver)
        {
            var login = "ANowak";
            var hasło = "Asd34%";
            var email = "mkowalska@gmail.com";
            var firma = "Firma Test";
            var imię = "Maria";
            var nazw = "Kowalska";
            var nrTel = "555672345";
            var pesel = "92481027926";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div[2]/a[1]")).Click();
            var input1 = driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input"));
            input1.Clear();
            input1.SendKeys(email);
            var input2 = driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input"));
            input2.Clear();
            input2.SendKeys(firma);
            var input3 = driver.FindElement(By.XPath("/html/body/div/main/form/div[3]/input"));
            input3.Clear();
            input3.SendKeys(imię);
            var input4 = driver.FindElement(By.XPath("/html/body/div/main/form/div[4]/input"));
            input4.Clear();
            input4.SendKeys(nazw);
            var input5 = driver.FindElement(By.XPath("/html/body/div/main/form/div[5]/input"));
            input5.Clear();
            input5.SendKeys(nrTel);
            var input6 = driver.FindElement(By.XPath("/html/body/div/main/form/div[6]/input"));
            input6.Clear();
            input6.SendKeys(pesel);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[7]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/button")).Submit();

            Assert.AreEqual("Konto - Hurtownia", driver.Title);
        }

        public static void UpdateHasłoTest(IWebDriver driver)
        {
            var login = "ANowak";
            var hasło = "Asd34%";
            var noweHasło = "Zxc12#";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div[2]/a[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[2]/input")).SendKeys(noweHasło);
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[3]/input")).SendKeys(noweHasło);
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/input[@type='submit']")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(noweHasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();

            Assert.AreEqual("Strona główna - Hurtownia", driver.Title);
        }

        public static void DodajKontoTest(IWebDriver driver)
        {
            var login = "Admin";
            var hasło = "Admin12#";
            var kontoLogin = "MCiszew";
            var email = "mciszewski@gmail.com";
            var kontoHasło = "Jkl45^";
            var nrTel = "555890462";
            var imię = "Marcin";
            var nazw = "Ciszewski";

            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/a")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(kontoLogin);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(email);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[3]/input")).SendKeys(kontoHasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[4]/input")).SendKeys(nrTel);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[5]/input")).SendKeys(imię);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[6]/input")).SendKeys(nazw);
            driver.FindElement(By.XPath("/html/body/div/main/form/button")).Submit();

            Assert.AreEqual("Lista pracowników - Hurtownia", driver.Title);
        }

        public static void UsuńKontoTest(IWebDriver driver)
        {
            var login = "Admin";
            var hasło = "Admin12#";
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul/li[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form/div[1]/input")).SendKeys(login);
            driver.FindElement(By.XPath("/html/body/div/main/form/div[2]/input")).SendKeys(hasło);
            driver.FindElement(By.XPath("/html/body/div/main/form/input")).Submit();
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[1]/ul/li[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[6]/form/button")).Submit();

            Assert.AreEqual("Lista pracowników - Hurtownia", driver.Title);
        }

    }
}
