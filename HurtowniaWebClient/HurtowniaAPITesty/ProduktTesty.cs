using HurtowniaAPI.Controllers;
using HurtowniaAPI.Dto.Produkt;
using HurtowniaAPI.Dto.Zdjęcie;
using HurtowniaAPI.Entities;
using HurtowniaAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HurtowniaAPITesty
{
    [TestClass]
    public class ProduktTesty
    {
        [TestMethod("GetProduktyTest")]
        public void GetProdukty()
        {
            var nazwa1 = "Telewizor LG 65QNED813QA - 65\" - 4K - Smart TV";
            var nazwa2 = "Telewizor Samsung QLED QE55Q60AAU - 55\" - 4K - Smart TV";
            var nazwa3 = "Telewizor Sony OLED XR-55A80J - 55\" - 4K - Google TV";
            var cena1 = 3413.821M;
            var cena2 = 2194.309M;
            var cena3 = 4308.13M;
            var vat = 0.23M;
            var ilość1 = 100;
            var ilość2 = 20;
            var ilość3 = 36;
            var opis1 = "Telewizor LG 65QNED813QA zachwyci cię głębią kolorów i płynnością działania. Doskonała jakość obrazu to zasługa m.in. technologii Quantum Dot + NanoCell oraz szybkiego procesora α7 AI. Gracze docenią bogatą bibliotekę gier w chmurze, a ThinQ AI oraz system webOS dopasują dla ciebie treści. Ciesz się szczegółowym obrazem z dużą liczbą detali w rozdzielczości 4K Zachwyć się głębią kolorów dzięki technologiom Quantum Dot + NanoCell Doskonałe wrażenia wizualne zapewnia szybki procesor α7 AI Personalizację ustawień urządzenia ułatwią ci sztuczna inteligencja i system webOS Graj w gry, oglądaj filmy i seriale albo korzystaj z biblioteki muzycznej jednej z wielu platform streamingowych Poznaj telewizor LG 65QNED813QA Niesamowite kolory Poczuj magię kolorów dzięki zastosowanym w LG 65QNED813QA technologiom. LG QNED, czyli Quantum Nano-Emitting Diodes, oraz Quantum Dot i NanoCell pozwalają wygaszać strefy ekranu, żeby nadać kolorom większą głębię i niesamowite nasycenie barw, minimalizując przy tym efekt halo. Obrazy są czyste, a kolory niezwykle wyraziste – dzięki temu doświadczysz ich prawdziwej ostrości. I to w 4K! Procesor α7 Szybki procesor α7 oraz sztuczna inteligencja zadbają o dostarczanie niezwykłych wrażeń wizualnych. Na pewno docenisz optymalizację treści, za którą odpowiedzialne są algorytmy przystosowane do głębokiego uczenia się. Tak działa ten innowacyjny czip, który umożliwia automatyczne dostosowanie zarówno dźwięku, jak i obrazu. LG 65QNED813QA zadba o każdy szczegół, żeby zapewnić ci rozrywkę na najwyższym poziomie technologicznym. Technologia Smart Urządzenie pozwala łatwo docierać do ulubionych aplikacji czy dopasowanych do twoich upodobań powiadomień. Zastanawiasz się, jak to możliwie? Wszystko dzięki sztucznej inteligencji ThinQ AI oraz systemowi webOS, które personalizują i dobierają treści do użytkownika. Steruj urządzeniem szybko i korzystaj z dobranych do ciebie rekomendacji – na tym polega prawdziwa technologia Smart w telewizorze LG 65QNED813QA. Granie bez ograniczeń Co powiesz na łatwy dostęp do niezliczonej ilości gier? Taką możliwość zyskujesz dzięki usłudze GEFORCE Now w telewizorze LG. Najnowsze tytuły będą w twoim zasięgu bez konieczności kupowania konsoli. To dopiero jest Cloud Gaming na wysokim poziomie! Technologia AMD FreeSync Premium Jeszcze jednym istotnym udoskonaleniem dla graczy jest technologia AMD FreeSync Premium, którą ma telewizor LG 65QNED813QA. To ona powoduje, że rozgrywki odbywają się płynnie, bez zbędnych przestojów i zacięć. Każdy fan gamingu na pewno doceni to rozwiązanie i zwiększy swoje szanse na zwycięstwo w każdej misji.";
            var opis2 = "Perfekcyjne kolory, które nigdy nie bledną dzięki Technologii Quantum Dot phpeysy0o kv q60a ok Najważniejsze cechy 100 natezenie kolorow Q60A 100% Natężenie Kolorów dzięki technologii Quantum Dot Dual LED Q60A Dual LED Quantum HDR Q60A Quantum HDR phpwubgr8 phplpm7st smukly-design Smukły Design Miliard perfekcyjnych odcieni kolorów 100% Natężenie Kolorów dzięki technologii Quantum Dot Dzięki technologi Quantum Dot obraz na Twoim telewizorze wypełni się miliardem różnorodnych odcieni. Barwy, które odkryjesz, z pewnością zrobią na Tobie niesamowite wrażenie. Quantum Dot perfekcyjne kolory *100% Natężenie Kolorów odtwarzanych treści, zmierzone według standardu DCI-P3, certyfikowane przez VDE. Głębia kolorów dzięki zastosowaniu dwóch barw podświetlenia LED Dual LED Dopasowanie temperatury koloru podświetlenia to wyraźny kontrast i mocniejsze nasycenie. Innowacyjna technologia Dual LED z chłodną i ciepłą tonacją dostosowuje nasycenie kolorów do oglądanej treści. glebia kolorow Dual LED Kinowa jakość głębi kontrastu Quantum HDR Bogata paleta kolorów oraz głęboki kontrast to wynik zastosowania technologii Quantum HDR, dzięki której dostrzeżesz więcej szczegółów na ekranie telewizora. Quantum HDR gleboki kontrast * Wartość funkcji Quantum HDR odnosi się do jasności mierzonej według własnych standardów i testów Samsung. Działanie Quantum HDR zależy od warunków, w jakich odtwarzany jest obraz. Procesor Quantum 4K Lite Procesor 4K w jeszcze szybszym i bardziej inteligentnym wydaniu Procesor Quantum 4K Lite Zapewnij sobie moc wrażeń i niezapomnianych chwil dzięki skalowaniu obrazu do rewelacyjnej jakości 4K* i Procesorowi Quantum 4K Lite, który inteligentnie dostosowuje dźwięk wyświetlanego filmu do warunków Twojego otoczenia. * Jakość wyświetlanej treści może się różnić w zależności od rodzaju treści i formatu. Kinowa jakość brzmienia Dźwięk Podążający za Obiektem Lite Ciesz się kinową jakością brzmienia dzięki technologii Dźwięku Podążającego za Obiektem Lite. Wbudowany w telewizor system głośników 2.0. dostarczy Ci jeszcze więcej realizmu i niepowtarzalnych wrażeń. Dźwięk Podążający za Obiektem Lite Harmonijne brzmienie soundbara i telewizora. Q-Symphony Oczekujesz prawdziwie intensywnych wrażeń podczas oglądania filmów? Funkcja Q-Symphony sprawia, że głośniki telewizora synchronizują się z soundbarem, zapewniając Ci wzmocniony i harmonijny dźwięk. * Funkcja Q-Symphony działa tylko z kompatybilnym soundbarem. Kompatybilność z funkcją Q-Symphony możesz sprawdzić w specyfikacji soundbara. Funkcja dostępna tylko dla wybranych soundbarów. harmonijne brzmienie Funkcja Adaptacji Dźwięku Dźwięk dopasowany do treści Funkcja Adaptacji Dźwięku Analiza i optymalizacja dźwięku w czasie rzeczywistym zapewnią Ci idealnie brzmienie i niezapomniane efekty dźwiękowe. Smukły i elegancki design Smukły Design Pełnia wdzięku i ultra nowoczesny design - Q60A wygląda perfekcyjnie pod każdym kątem i każdym wnętrzu. Smukły i elegancki design * Rzeczywisty produkt może różnić się od przedstawionego na zdjęciu. Zapraszamy do obejrzenia naszej galerii produktów. Regulowana Podstawa Q60A Regulacja wysokości telewizora Regulowana Podstawa Regulowana wysokość ramy telewizora daje możliwość dopasowania jej do soundbaru lub innego urządzenia. Przestrzeń wokół Twojego Q60A będzie stylowa i dobrze przemyślana. Udoskonalona dynamika ruchu w relacjach sportowych Upłynniacz Ruchu Oto rewelacyjna jakość transmitowanych rozgrywek piłkarskich lub wydarzeń sportowych uzyskana dzięki zaawansowanej funkcji płynnego ruchu. Wyświetlane na telewizorze materiały będą od dziś pełne dynamiki, bez rozmycia obrazu czy opóźnień ruchu. Upłynniacz Ruchu komfort podczas gry Większy komfort podczas gry Ultra Szeroki Widok w Grach i Panel Gracza Panel Gracza Intuicyjny panel sterujący funkcjami dla graczy Dzięki sterowanemu intuicyjnie panelowi dla graczy możesz wygodnie zmienić ustawienia bez konieczności opuszczania gry. Masz też możliwość błyskawicznego sprawdzenia liczby wyświetlanych klatek na sekundę (FPS) czy skali input laga. Ultra Szeroki Widok w Grach Lepsza widoczność w grach dzięki ultra szerokim proporcjom obrazu Dzięki funkcji Ultra Szeroki Widok w Grach (21:9 lub 32:9) otrzymasz lepszą widoczność i proporcje obrazu podczas gry. Doświadczaj jakości obrazu zupełnie jak na ultra szerokich monitorach dla graczy. * Ultra Szeroki Widok jest dostępny tylko dla gier komputerowych ze wsparciem dla funkcji Ultra Szerokiego Widoku. * Niektóre gry mogą nie obsługiwać tej funkcji lub jej obsługa może być ograniczona. * Zmiana rozdzielczości ekranu może wymagać użycia urządzenia zewnętrznego. Natychmiastowa reakcja na Twój każdy ruch Automatyczny Tryb Gry Telewizor Q60A zapewni Ci rozgrywki gamingowe bez opóźnień ruchu i rozmyć obrazu, a Automatyczny Tryb Gry wyłapie nawet trudno zauważalne opóźnienia. * Niskie opóźnienie wejściowe mierzone jest na podstawie wewnętrznych warunków testowych i może ulec zmianie w zależności od ustawień gry lub określonych warunków. Automatyczny Tryb Gry Wykorzystanie TV jako monitora komputera PC na Ekranie TV Pracujesz w domu? Wykorzystaj telewizor do pracy zdalnej dzięki bezprzewodowemu połączeniu z firmowym komputerem, notebookiem lub smartfonem. Funkcja obsługuje Office 365 oraz tryb Samsung DeX. PC na Ekranie TV * Zdalne połączenie z komputerem jest obsługiwane tylko w przypadku systemu Windows 10 Professional lub nowszego oraz Mac OS 10.5 lub nowszego. * Automatyczne rozpoznawanie komputera biurowego wymaga instalacji aplikacji Easy Connection na komputerze PC (nieobsługiwana w systemie Mac OS). * Obsługa funkcji aplikacji Easy Connection może się różnić w zależności od typu modelu i daty. * Połączenie smartfona z Samsung DeX wymaga kompatybilnego urządzenia mobilnego. * Dostępność usług może ulec zmianie bez wcześniejszego powiadomienia. * Wymagane jest połączenie internetowe na telewizorze i komputerze. Oglądanie treści z kilku urządzeń na jednym ekranie Multi View Nieważne, czy analizujesz statystyki sportowe, czy oglądasz tutorial do gry - możesz je wyświetlać jednocześnie na jednym urządzeniu - na ekranie swojego telewizora. Już nie musisz wybierać pomiędzy telefonem a TV. Możesz je połączyć i oglądać na jednym ekranie wszystko to, czego w danym momencie potrzebujesz. Multi View tresci z urzadzen na ekranie * Wymagane urządzenie z systemem Android (4.2 lub nowszym) lub systemem iOS wspierającym AirPlay2 oraz pobranie i instalacja aplikacji SmartThings. Szczegółowe informacje na temat kompatybilnych urządzeń mobilnych można znaleźć na stronie pomocy technicznej. Dotknij i Wyświetl Połącz smartfon z dużym ekranem za pomocą jednego dotknięcia Dotknij i Wyświetl Przesyłanie filmów lub muzyki z telefonu na telewizor jest niezwykle proste. Z funkcją Dotknij i Wyświetl szybko i wygodnie wyświetlisz treści z telefonu na telewizorze. Możesz oglądać na dużym ekranie to, co lubisz najbardziej. Jednym ruchem dotknij telefonem telewizora, a urządzenie wykryje i wyświetli materiały z Twojego telefonu na dużym ekranie. * Ta usługa działa tylko wtedy, gdy telewizor i smartfon są włączone. * Funkcja Dotknij i Wyświetl jest dostępna na urządzeniach Samsung Galaxy z systemem Android 8.1 lub nowszym.";
            var opis3 = "Zanurz się w głębi obrazu i dźwięku OLED OLED zapewnia niezrównane poziomy czerni, kontrast i kolory Układ Cognitive Processor XR™ odtwarza sposób w jaki widzimy i słyszymy, by zapewnić wciągające wrażenia Ekran będący jednocześnie głośnikiem w połączeniu z najnowszym procesorem XR zamienią każdy dźwięk w intensywne doznanie Swoboda wyboru miejsca na telewizor dzięki różnym ustawieniom podstawy Obraz Obraz XR Pozwól zachwycić się kontrastem naszego najlepszego telewizora OLED i głębią naturalnie wyglądającego, realistycznego obrazu. Rewolucyjny procesor wykorzystuje ludzką perspektywę, by w mgnieniu oka kompleksowo przeanalizować i zoptymalizować setki tysięcy elementów, a w połączeniu z niezwykłym panelem OLED zapewnić czystą czerń i najwyższą jasność. Kontrast XR Procesor Sony Cognitive Processor XR kompleksowo analizuje dane i ulepsza te cechy obrazu, na których skupia się oko ludzkie, zapewniając realistyczne kolory i głębię. Funkcja Kontrast XR OLED Pro dostosowuje jasność do najbardziej intensywnych świateł i głębokiej czerni w cieniach. Dzięki niej detale nie giną już w cieniu i nie ulegają prześwietleniu. Kolor XR Nasz unikatowy wyświetlacz wyposażony w Cognitive Processor XR™ i technologię XR Triluminos Pro™, reprodukuje szerszą paletę barw i najbardziej nietypowe odcienie kolorów — dzięki temu wyglądają jak w świecie rzeczywistym. Rozszerzona skala barw i nasycenia pozwoli oglądać żywe odcienie i realistyczne faktury kwiatów. Naturalnie wyglądają nawet pastelowe kolory. XR HDR Remaster Technologia XR HDR Remaster umożliwia identyfikację poszczególnych obiektów na ekranie, analizę ich koloru i dostosowanie kontrastu. Takie obiektowe przetwarzanie, oparte na technologii BRAVIA XR™, jest bez porównania bardziej precyzyjne, ponieważ pozwala korygować kolorystykę, nasycenie, jasność, wektor ruchu, przepustowość i inne parametry. W rezultacie oglądasz wyjątkowo realistyczne sceny z większą głębią, wiernie oddanymi fakturami i naturalnymi kolorami. Czystość XR Technologia interpolacji XR 4K zapewnia jakość zbliżoną do 4K niezależnie od źródła obrazu. Procesor Cognitive Processor XR przetwarza ogromne ilości danych i zwiększa realizm obrazu, inteligentnie rekonstruując faktury i detale. W rezultacie futro zwierzęcia ma naturalny wygląd, a skała — ostry zarys. Interpolacja XR 4K Procesor Cognitive Processor XR nadaje sygnałom 2K jakość zbliżoną do 4K, dzięki czemu obraz staje się niesamowicie realistyczny i wciągający.  Do interpolacji XR 4K wykorzystywane są duże ilości danych. Umożliwia to analizę wzorów w scenach i rekonstrukcję drobnych detali. 4K XR Super Resolution Technologia XR Super Resolution wykrywa poszczególne obiekty w obrazie, a reprodukowane przez nią faktury praktycznie nie różnią się wyglądem od rzeczywistości. Procesor BRAVIA XR dokładnie analizuje i przetwarza dane, by zapewnić realistyczne detale i faktury w obrazach o rozdzielczości 4K — czterokrotnie wyższej niż Full HD. Wygładzanie XR 4K Wygładzanie XR tworzy łagodny, naturalny obraz 4K bez widocznych pasm kolorów, które mogą występować na innych telewizorach. W wyświetlanych scenach pojawiają się tysiące odcieni i przejść, co nadaje obrazowi niezwykle realistyczny wygląd. Ruch XR Sport i kino akcji wyglądają teraz bez porównania lepiej. Procesor Cognitive Processor XR z technologią XR Motion Clarity™ kompleksowo analizuje dane, by zapewnić płynność akcji i jasny, wyraźny obraz. XR Motion Clarity Obraz na telewizorze OLED składa się z milionów indywidualnie sterowanych pikseli, które w połączeniu z technologią OLED XR Motion Clarity™ sprawiają, że nawet szybkie sceny wyglądają ostro i wyraźnie. Aby uniknąć ich zamazywania się i utraty jasności, zmieniające się obrazy są poddawane precyzyjnemu przetwarzaniu. Idealny do gier Telewizor BRAVIA pomoże Ci zdobyć przewagę nad rywalami. Wejście HDMI 2.1 umożliwia wyświetlanie obrazu z szybkością 120 kl./s. Błyskawiczne aktualizowanie obrazu da Ci przewagę podczas strzelania, zmagań sportowych i w innych grach z dynamiczną akcją. Wynoszące niespełna 8,5 ms opóźnienie sygnału wejściowego w trybie 4K / 120 kl./s i specjalny tryb Gra nadadzą grze wyjątkową płynność. Dźwięk Położenie dźwięku XR Aby dźwięk harmonizował z naszym postrzeganiem świata, funkcja XR Sound Position sprawia, że słychać go zza obrazu. Ekran tego telewizora OLED 4K BRAVIA XR jest także głośnikiem, zatem dźwięk dokładnie pasuje do wyświetlanego obrazu i naprawdę wciąga. Acoustic Surface Audio + Dzięki technologii Acoustic Surface Audio+ dźwięk dobiega prosto ze środka ekranu. Wytwarzają go mocne siłowniki za wyświetlaczem. Ich wibracja powoduje powstanie dźwięku, który przemieszcza się z obrazem. Ponieważ dźwięk podąża za akcją, słyszysz bardziej realistyczne dialogi i efekty dźwiękowe. Skierowany do przodu subwoofer emituje mocny bas i sprawia, że nie przeoczysz żadnego elementu akcji na ekranie. Siłowniki i subwoofer gwarantują stabilny dźwięk niezależnie od tego, czy telewizor wisi na ścianie, czy stoi na  podstawie. Dźwięk przestrzenny XR Dzięki technologii BRAVIA XR każdy oglądany obraz zostanie uzupełniony dźwiękiem przestrzennym. Funkcja XR Surround generuje dźwięk przestrzenny w płaszczyźnie poziomej  i pionowej. Zyskujesz więc efekt 3D bez głośników sufitowych lub zwróconych do góry. Interpolacja dźwięku przestrzennego 3D Technologia przetwarzania sygnału BRAVIA XR umożliwia reprodukcję wciągającego, wielowymiarowego dźwięku. Przekonasz się, że otaczające Cię dźwięki dobiegają nie tylko w poziomie , ale również w pionie. Interpolacja dźwięku przestrzennego 3D wprowadzi do domu emocjonujące brzmienie najnowszych kinowych formatów audio, takich jak Dolby Atmos®, i zapewni efekt przestrzenny nawet w zwykłych stereofonicznych nagraniach. Piękna forma Ustawiana na trzy sposoby podstawa Do wyboru są trzy ustawienia podstawy: standardowe, przy którym uwaga skupia się na obrazie, wąskie do umieszczenia telewizora na mniejszej półce oraz dopasowane do soundbara. Wzornictwo Seamless Edge Bezramkowa konstrukcja nadaje temu telewizorowi finezyjny wygląd i skupia całą uwagę na tym, co najważniejsze — obrazie. Stylistyka One Slate Zgodnie z naszą koncepcją One Slate telewizor stanowi ważny element przestrzeni mieszkalnej: wyświetla grafikę i prywatne zdjęcia, pozwala wybierać motywy wygaszacza ekranu i zapewnia funkcje zegara. Lifestyle Google TV Przeglądaj ponad 700 000 filmów i programów telewizyjnych z różnych serwisów streamingowych. Znajdziesz je wszystkie w jednym miejscu — uporządkowane tematycznie i podzielone na gatunki odpowiednio do Twoich zainteresowań. Wyszukiwanie głosowe Teraz jeszcze szybciej znajdziesz ulubione treści — używając własnego głosu. Dzięki wyszukiwaniu głosowemu unikasz skomplikowanej nawigacji i męczącego wpisywania. Wystarczy, że zapytasz. BRAVIA CORE™ Dedykowana telewizorom Sony Bravia XR platforma Bravia Core oferuje dostęp do ogromnej ilości filmów. Dzięki technologiom BRAVIA XR, Pure Stream i IMAX Enhanced masz możliwość oglądania nadzwyczajnego obrazu i dźwięku w najwyższej jakości. Czujnik światła Jeśli zmieni się intensywność światła w pomieszczeniu — na przykład wieczorem lub w słoneczny dzień — odpowiednio, automatycznie zmienią się też parametry jasności obrazu. Ten telewizor jest wyposażony w czujnik światła i regulacje krzywej tonalnej, który optymalizuje jasność odpowiednio do źródła światła i warunków panujących w pomieszczeniu. Współpraca z Apple AirPlay i Apple HomeKit Dzięki Apple AirPlay możesz przesyłać strumieniowo wideo i audio do telewizora bezpośrednio z iPhone'a, iPada lub Maca. Oglądaj filmy i programy z aplikacji Apple TV, ulubionych aplikacji, a nawet Safari. Udostępnij swoje zdjęcia wszystkim w pokoju. Wbudowany Chromecast Telewizor z technologią Chromecast built-in pozwala wyświetlać — w pełnej jakości — filmy, gry i aplikacje z urządzeń mobilnych. Aby obejrzeć ulubione treści na dużym ekranie, wystarczy wybrać ikonę przesyłania na urządzeniu z systemem Android lub iOS. Gdy zacznie się przesyłanie, możesz dalej przeglądać Internet na telefonie lub tablecie. Acoustic Auto Calibration Telewizor wykrywa miejsce, w którym siedzisz, i odpowiednio optymalizuje dźwięk. W rezultacie brzmi on tak, jak przy słuchaniu naprzeciwko ekranu telewizora. Na odbiór dźwięku mogą wpływać różne elementy wnętrza. Przykładowo, zasłony tłumią dźwięk, a przedmioty stojące przed telewizorem utrudniają emisję i pogarszają wrażenia przy słuchaniu. Ten telewizor wykrywa przedmioty i dostosowuje reprodukcję dźwięku do konkretnego wnętrza. Netflix Calibrated Mode Tryb Netflix Calibrated Mode został zaprojektowany z myślą o oglądaniu oryginalnych produkcji serwisu Netflix w studyjnej jakości obrazu. Dzięki temu trybowi intencje twórców są wiernie odwzorowane. IMAX Enhanced Ten telewizor 4K Smart TV Sony ma certyfikat IMAX Enhanced — świadectwo najwyższej wierności obrazu i dźwięku. Włącz tryb obrazu IMAX Enhanced, aby w pełni wykorzystywać zremasterowane materiały IMAX Enhanced i zapewnić sobie jeszcze bardziej pasjonującą rozrywkę. Dolby Vision® i Dolby Atmos® Przenieś kino do domu. Dzięki systemowi Dolby Vision® sceny stają się żywsze i bardziej autentyczne. Z kolei Dolby Atmos® wypełnia pomieszczenie wszechogarniającym dźwiękiem przestrzennym. Inteligentny pilot Do obsługi wszystkich połączonych urządzeń wystarczy Ci jeden inteligentny pilot. Jednym naciśnięciem przycisku przejdziesz też do serwisu z filmami na życzenie, by już po chwili w pokoju zagościły ulubione filmy i programy. ";
            var id1 = 1;
            var id2 = 2;
            var id3 = 3;

            var options = new DbContextOptionsBuilder<HurtowniaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;

            using(var context =  new HurtowniaDbContext(options))
            {
                context.Produkty.Add(new Produkt() { Id = id1, Nazwa = nazwa1, Cena = cena1, VAT = vat, Ilość = ilość1, Opis = opis1 });
                context.Produkty.Add(new Produkt() { Id = id2, Nazwa = nazwa2, Cena = cena2, VAT = vat, Ilość = ilość2, Opis = opis2 });
                context.Produkty.Add(new Produkt() { Id = id3, Nazwa = nazwa3, Cena = cena3, VAT = vat, Ilość = ilość3, Opis = opis3 });
                context.SaveChanges();
            }

            using (var context = new HurtowniaDbContext(options))
            {
                var controller = new ProduktController(new ProduktService(context));
                var produkty = controller.GetProdukty().ToArray();

                Assert.IsNotNull(produkty);
                Assert.AreEqual(3, produkty.Length);
                Assert.AreEqual(id1, produkty[0].Id);
                Assert.AreEqual(id2, produkty[1].Id);
                Assert.AreEqual(id3, produkty[2].Id);
                Assert.AreEqual(cena1 * (1M + vat), produkty[0].Cena);
                Assert.AreEqual(cena2 * (1M + vat), produkty[1].Cena);
                Assert.AreEqual(cena3 * (1M + vat), produkty[2].Cena);
                Assert.AreEqual(nazwa1, produkty[0].Nazwa);
                Assert.AreEqual(nazwa2, produkty[1].Nazwa);
                Assert.AreEqual(nazwa3, produkty[2].Nazwa);
            }
 
        }

        [TestMethod("GetProduktTest")]
        public void GetProdukt()
        {
            var nazwa1 = "Produkt1";
            var nazwa2 = "Produkt2";
            var nazwa3 = "Produkt3";
            var cena1 = 60.00M;
            var cena2 = 25.00M;
            var cena3 = 100.00M;
            var vat = 0.23M;
            var ilość1 = 100;
            var ilość2 = 20;
            var ilość3 = 36;
            var opis1 = "Lorem ipsum docet";
            var opis2 = "Lorem ipsum";
            var opis3 = "Lorem";
            var zdjęcieNazwa1 = "Zdjęcie1";
            var zdjęcieNazwa2 = "Zdjęcie2";
            var zdjęcia = new List<Zdjęcie>() { new Zdjęcie() { Id = 1, Nazwa = zdjęcieNazwa1, ProduktId = 2 }, new Zdjęcie() { Id = 2, Nazwa = zdjęcieNazwa2, ProduktId = 2 } };
            var id = 2;

            var options = new DbContextOptionsBuilder<HurtowniaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;

            using (var context = new HurtowniaDbContext(options))
            {
                context.Produkty.Add(new Produkt() { Id = 1, Nazwa = nazwa1, Cena = cena1, VAT = vat, Ilość = ilość1, Opis = opis1 });
                context.Produkty.Add(new Produkt() { Id = 2, Nazwa = nazwa2, Cena = cena2, VAT = vat, Ilość = ilość2, Opis = opis2, Zdjęcia = zdjęcia });
                context.Produkty.Add(new Produkt() { Id = 3, Nazwa = nazwa3, Cena = cena3, VAT = vat, Ilość = ilość3, Opis = opis3 });
                context.SaveChanges();
            }

            using (var context = new HurtowniaDbContext(options))
            {
                var controller = new ProduktController(new ProduktService(context));
                var produkt = controller.GetProdukt(id).Result.Value;

                Assert.IsNotNull(produkt);
                Assert.AreEqual(id, produkt.Id);
                Assert.AreEqual((cena2 * vat) + cena2, produkt.Cena);
                Assert.AreEqual(nazwa2, produkt.Nazwa);
                Assert.AreEqual(opis2, produkt.Opis);
                Assert.AreEqual(2, produkt.Zdjęcia.Count);
                Assert.AreEqual(1, produkt.Zdjęcia[0].Id);
                Assert.AreEqual(2, produkt.Zdjęcia[1].Id);
                Assert.AreEqual(zdjęcieNazwa1, produkt.Zdjęcia[0].Nazwa);
                Assert.AreEqual(zdjęcieNazwa2, produkt.Zdjęcia[1].Nazwa);
            }

        }

        [TestMethod("PostProduktTest")]
        public void PostProdukt()
        {
            var nazwa = "Telewizor LG 65QNED813QA - 65\" - 4K - Smart TV";
            var cena = 3413.821M;
            var vat = 0.23M;
            var ilość = 50;
            var opis = "Telewizor LG 65QNED813QA zachwyci cię głębią kolorów i płynnością działania. Doskonała jakość obrazu to zasługa m.in. technologii Quantum Dot + NanoCell oraz szybkiego procesora α7 AI. Gracze docenią bogatą bibliotekę gier w chmurze, a ThinQ AI oraz system webOS dopasują dla ciebie treści. Ciesz się szczegółowym obrazem z dużą liczbą detali w rozdzielczości 4K Zachwyć się głębią kolorów dzięki technologiom Quantum Dot + NanoCell Doskonałe wrażenia wizualne zapewnia szybki procesor α7 AI Personalizację ustawień urządzenia ułatwią ci sztuczna inteligencja i system webOS Graj w gry, oglądaj filmy i seriale albo korzystaj z biblioteki muzycznej jednej z wielu platform streamingowych Poznaj telewizor LG 65QNED813QA Niesamowite kolory Poczuj magię kolorów dzięki zastosowanym w LG 65QNED813QA technologiom. LG QNED, czyli Quantum Nano-Emitting Diodes, oraz Quantum Dot i NanoCell pozwalają wygaszać strefy ekranu, żeby nadać kolorom większą głębię i niesamowite nasycenie barw, minimalizując przy tym efekt halo. Obrazy są czyste, a kolory niezwykle wyraziste – dzięki temu doświadczysz ich prawdziwej ostrości. I to w 4K! Procesor α7 Szybki procesor α7 oraz sztuczna inteligencja zadbają o dostarczanie niezwykłych wrażeń wizualnych. Na pewno docenisz optymalizację treści, za którą odpowiedzialne są algorytmy przystosowane do głębokiego uczenia się. Tak działa ten innowacyjny czip, który umożliwia automatyczne dostosowanie zarówno dźwięku, jak i obrazu. LG 65QNED813QA zadba o każdy szczegół, żeby zapewnić ci rozrywkę na najwyższym poziomie technologicznym. Technologia Smart Urządzenie pozwala łatwo docierać do ulubionych aplikacji czy dopasowanych do twoich upodobań powiadomień. Zastanawiasz się, jak to możliwie? Wszystko dzięki sztucznej inteligencji ThinQ AI oraz systemowi webOS, które personalizują i dobierają treści do użytkownika. Steruj urządzeniem szybko i korzystaj z dobranych do ciebie rekomendacji – na tym polega prawdziwa technologia Smart w telewizorze LG 65QNED813QA. Granie bez ograniczeń Co powiesz na łatwy dostęp do niezliczonej ilości gier? Taką możliwość zyskujesz dzięki usłudze GEFORCE Now w telewizorze LG. Najnowsze tytuły będą w twoim zasięgu bez konieczności kupowania konsoli. To dopiero jest Cloud Gaming na wysokim poziomie! Technologia AMD FreeSync Premium Jeszcze jednym istotnym udoskonaleniem dla graczy jest technologia AMD FreeSync Premium, którą ma telewizor LG 65QNED813QA. To ona powoduje, że rozgrywki odbywają się płynnie, bez zbędnych przestojów i zacięć. Każdy fan gamingu na pewno doceni to rozwiązanie i zwiększy swoje szanse na zwycięstwo w każdej misji.";
            var zdjęcieNazwa1 = "Granny_Smith_Apples231819925.jpg";
            var zdjęcieNazwa2 = "Taglilie234231534.jpg";
            var zdjęcia = new List<ZdjęcieDto>() { new ZdjęcieDto() { Id = 1, Nazwa = zdjęcieNazwa1 }, new ZdjęcieDto() { Id = 2, Nazwa = zdjęcieNazwa2 } };

            var options = new DbContextOptionsBuilder<HurtowniaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;

            using var context = new HurtowniaDbContext(options);
            var controller = new ProduktController(new ProduktService(context));
            controller.PostProdukt(new ProduktFullDto() { Id = 1, Cena = cena, Ilość = ilość, Nazwa = nazwa, Opis = opis, VAT = vat, Zdjęcia = zdjęcia }).Wait();
            var produkt = context.Produkty.FirstOrDefault();

            Assert.IsNotNull(produkt);
            Assert.AreEqual(1, produkt.Id);
            Assert.AreEqual(cena, produkt.Cena);
            Assert.AreEqual(ilość, produkt.Ilość);
            Assert.AreEqual(nazwa, produkt.Nazwa);
            Assert.AreEqual(opis, produkt.Opis);
            Assert.AreEqual(vat, produkt.VAT);
            Assert.IsNotNull(produkt.Zdjęcia);
            Assert.AreEqual(1, produkt.Zdjęcia[0].Id);
            Assert.AreEqual(2, produkt.Zdjęcia[1].Id);
            Assert.AreEqual(zdjęcieNazwa1, produkt.Zdjęcia[0].Nazwa);
            Assert.AreEqual(zdjęcieNazwa2, produkt.Zdjęcia[1].Nazwa);
        }

        [TestMethod("PutProduktTest")]
        public void PutProdukt()
        {
            var nazwa1 = "Test";
            var cena1 = 100.00M;
            var vat1 = 0.23M;
            var ilość1 = 50;
            var opis1 = "Lorem ipsum";
            var zdjęcieNazwa1 = "Zdjęcie1";
            var zdjęcieNazwa2 = "Zdjęcie2";
            var zdjęcia1 = new List<Zdjęcie>() { new Zdjęcie() { Id = 1, Nazwa = zdjęcieNazwa1, ProduktId = 1 }, new Zdjęcie() { Id = 2, Nazwa = zdjęcieNazwa2, ProduktId = 1 } };
            var nazwa2 = "Produkt1";
            var cena2 = 50.00M;
            var vat2 = 0.10M;
            var ilość2 = 100;
            var opis2 = "Docet";
            var zdjęcieNazwa3 = "Zdjęcie3";
            var zdjęcieNazwa4 = "Zdjęcie4";
            var zdjęcia2 = new List<ZdjęcieDto>() { new ZdjęcieDto() { Id = 3, Nazwa = zdjęcieNazwa3 }, new ZdjęcieDto() { Id = 4, Nazwa = zdjęcieNazwa4 } };
            var doUsun = new List<string>() { zdjęcieNazwa1, zdjęcieNazwa2 };

            var options = new DbContextOptionsBuilder<HurtowniaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;

            using (var context = new HurtowniaDbContext(options))
            {
                context.Produkty.Add(new Produkt() { Id = 1, Cena = cena1, Ilość = ilość1, Nazwa = nazwa1, Opis = opis1, VAT = vat1, Zdjęcia = zdjęcia1 });
                context.SaveChanges();
            }

            using (var context = new HurtowniaDbContext(options))
            {
                var controller = new ProduktController(new ProduktService(context));
                controller.PutProdukt(1, new ProduktUpdateDto() { Id = 1, Cena = cena2, Ilość = ilość2, Nazwa = nazwa2, Opis = opis2, VAT = vat2, DoUsun = doUsun, Zdjęcia = zdjęcia2 }).Wait();
                var produkt = context.Produkty.FirstOrDefault();

                Assert.IsNotNull(produkt);
                Assert.AreEqual(1, produkt.Id);
                Assert.AreEqual(cena2, produkt.Cena);
                Assert.AreEqual(ilość2, produkt.Ilość);
                Assert.AreEqual(nazwa2, produkt.Nazwa);
                Assert.AreEqual(opis2, produkt.Opis);
                Assert.AreEqual(vat2, produkt.VAT);
                Assert.IsNotNull(produkt.Zdjęcia);
                Assert.AreEqual(3, produkt.Zdjęcia[0].Id);
                Assert.AreEqual(4, produkt.Zdjęcia[1].Id);
                Assert.AreEqual(zdjęcieNazwa3, produkt.Zdjęcia[0].Nazwa);
                Assert.AreEqual(zdjęcieNazwa4, produkt.Zdjęcia[1].Nazwa);
            }

        }

        [TestMethod("DeleteProduktTest")]
        public void DeleteProdukt()
        {
            var nazwa1 = "Produkt1";
            var nazwa2 = "Produkt2";
            var nazwa3 = "Produkt3";
            var cena1 = 60.00M;
            var cena2 = 25.00M;
            var cena3 = 100.00M;
            var vat = 0.23M;
            var ilość1 = 100;
            var ilość2 = 20;
            var ilość3 = 36;
            var opis1 = "Lorem ipsum docet";
            var opis2 = "Lorem ipsum";
            var opis3 = "Lorem";
            var produkt1 = new Produkt() { Id = 1, Nazwa = nazwa1, Cena = cena1, VAT = vat, Ilość = ilość1, Opis = opis1, Zamówienia = null, Zdjęcia = null };
            var produkt2 = new Produkt() { Id = 2, Nazwa = nazwa2, Cena = cena2, VAT = vat, Ilość = ilość2, Opis = opis2, Zamówienia = null, Zdjęcia = null };
            var produkt3 = new Produkt() { Id = 3, Nazwa = nazwa3, Cena = cena3, VAT = vat, Ilość = ilość3, Opis = opis3, Zamówienia = null, Zdjęcia = null };
            var id = 2;

            var options = new DbContextOptionsBuilder<HurtowniaDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;

            using (var context = new HurtowniaDbContext(options))
            {
                context.Produkty.Add(produkt1);
                context.Produkty.Add(produkt2);
                context.Produkty.Add(produkt3);
                context.SaveChanges();
            }

            using (var context = new HurtowniaDbContext(options))
            {
                var controller = new ProduktController(new ProduktService(context));
                controller.DeleteProdukt(id).Wait();
                var produkty = context.Produkty.ToList();

                Assert.IsNotNull(produkty);
                Assert.AreEqual(2, produkty.Count);
                Assert.IsFalse(produkty.Exists(p => p.Id == id));
            }

        }

    }
}