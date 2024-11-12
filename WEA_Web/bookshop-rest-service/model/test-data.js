const Book = require("./book");

const pictureUrl = 'images/';

const books = [];

b = new Book();
b.id = "1";
b.author = "Mann Thomas";
b.title = "Die Bekenntnisse des Hochstaplers Felix Krull";
b.price = "9.90";
b.publisher = "Fischer";
b.year = "1989";
b.description = "Felix Krull ist ein Tausendsassa und Hochstapler: In jeder Situation versteht er es, das Beste für sich daraus zu machen. Also fälscht er die Unterschrift seines Vaters für die Schule. Er simuliert den soldatisch begeisterten Epileptiker, um desto sicherer befreit zu sein. Und er nutzt alle Wege, um seiner »Begabung zur Liebeslust« zu entsprechen ..." +
        "Thomas Manns populärer Gauner-Roman ist eine fiktive Autobiographie, deren jugendlicher Held im Sturm die Herzen der Leser erobert: Kein abgeklärtes Alterswerk, sondern eine parodistische Abenteuergeschichte von höchster sprachlicher Eleganz.";
b.isbn = "978-3596294299";
b.picture = pictureUrl + "Die_Bekenntnisse_des_Hochstaplers_Felix_Krull.jpg";
books.push(b);

b = new Book();
b.id = "2";
b.author = "Buchberger Bruno";
b.title = "Mathematik, Management, Mediation";
b.price = "22.90";
b.publisher = "Molden";
b.year = "2016";
b.description = "Mathematik die Kunst des Denkens Management die Kunst des Handelns Meditation die " +
        "Kunst des Nicht-Denkens und Nicht-Handelns Der vielfach ausgezeichnete Mathematiker, " +
        "Computerwissenschafts-Pionier und Softwarepark-Gründer Bruno Buchberger kondensiert in " +
        "diesem Buch seine Gedanken zu diesen zentralen Aspekten seines Lebens. Dafür wühlt er " +
        "nicht die Form einer klassischen Autobiografie, sondern setzt sich mit Fragen auseinander, " +
        "die ihm in dieser oder ähnlicher Form im Lauf der Jahre in Interviews gestellt wurden. " +
        "Für Eilige formuliert er die Antworten als kurze, mitunter provokante Schlaglichter. " +
        "Für Leser, die in die Tiefe gehen wollen, erarbeitet der Autor die Zusammenhänge in " +
        "umfassenderen Diskursen und Anekdoten. Ein Buch für alle, die denken, handeln und sich " +
        "manchmal nach dem Nicht-Denken und Nicht-Handeln sehnen.";
b.isbn = "978-3854853411";
b.picture = pictureUrl + "Mathematik-Management-Meditation.jpg";
books.push(b);

b = new Book();
b.id = "3";
b.author = "Erik Brynjolfsson";
b.title = "The Second Machine Age: Work, Progress, and Prosperity in a Time of Brilliant Technologies";
b.price = "9.99";
b.publisher = "Springer";
b.year = "2016";
b.description = "In The Second Machine Age MIT s Erik Brynjolfsson and Andrew McAfee two thinkers at" +
        " the forefront of their field reveal the forces driving the reinvention of our lives " +
        "and our economy. As the full impact of digital technologies is felt, we will realize " +
        "immense bounty in the form of dazzling personal technology, advanced infrastructure, " +
        "and near-boundless access to the cultural items that enrich our lives." +
        "Amid this bounty will also be wrenching change. Professions of all kinds from lawyers " +
        "to truck drivers will be forever upended. Companies will be forced to transform or die. " +
        "Recent economic indicators reflect this shift: fewer people are working, and wages are " +
        "falling even as productivity and profits soar.";
b.isbn = "978-3864705946";
b.picture = pictureUrl + "The_Second_Machine_Age.jpg";
books.push(b);

b = new Book();
b.id = "4";
b.author = "Ford Martin";
b.title = "The Rise of the Robots";
b.price = "9.90";
b.publisher = "Oneworld Publications";
b.year = "2015";
b.description = "If a 'robot' could do your job quicker than you and better than you for no pay, would " +
        "you still be employed? Today it's travel agents, data-analyst and paralegals whose jobs " +
        "are under threat. Soon it will be doctors, taxi-drivers and, ironically, even computer " +
        "programmers. Without a radical reassessment of our economic and political structures, we " +
        "risk the implosion of the capitalist economy itself. In a frightening tour of artificial " +
        "intelligence's rapid advances, technology expert Martin Ford draws on a wealth of economic" +
        " data from both the US and the UK to outline the terrifying societal implications of the " +
        "robots' rise. From health and education to finance and technology, his warning is stark: " +
        "any job that is on some level routine is likely to be automated and if we are to see a " +
        "future of prosperity rather than catastrophe we must act now.";
b.isbn = "978-1780748481";
b.picture = pictureUrl + "Rise_of_the_Robots.jpg";
books.push(b);

b = new Book();
b.id = "5";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Milchgeld. Kommissar Kluftingers erster Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2006";
b.description = "Ein Mord in Kommissar Kluftingers beschaulichem Allgäuer Heimatort Altusried - jäh " +
        "verdirbt diese Nachricht sein gemütliches Kässpatzenessen. Ein Lebensmittelchemiker des " +
        "örtlichen Milchwerks ist stranguliert worden. Mit eigenwilligen Ermittlungsmethoden " +
        "riskiert der liebenswert-kantige Kommissar einen Blick hinter die Fassade der Allgäuer " +
        "Postkartenidylle und entdeckt einen scheinbar vergessenen Verrat, dunkle Machenschaften " +
        "und einen handfesten Skandal.";
b.isbn = "978-3492242165";
b.picture = pictureUrl + "Milchgeld_Kluftingers_erster_Fall.jpg";
books.push(b);

b = new Book();
b.id = "6";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Erntedank. Kommissar Kluftingers zweiter Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2007";
b.description = "Der Allgäuer Kriminalkommissar Kluftinger traut seinen Augen nicht: Auf der Brust eines toten Mannes in einem Wald bei Kempten liegt, sorgfältig drapiert, eine tote Krähe. Im Lauf der Ermittlungen taucht der Kommissar immer tiefer in die mystische Vergangenheit des Allgäus ein, und es beginnt ein Katz-und-Maus-Spiel mit dem Mörder, bei dem die Zeit gegen ihn arbeitet. Denn alle Zeichen sprechen dafür, dass das Morden weitergeht … Mit eigenwilligen Ermittlungsmethoden riskiert der liebenswert-kantige Kommissar einen Blick hinter die Fassade der Allgäuer Postkartenidylle und deckt Abgründe auf.";
b.isbn = "978-3492245111"
b.picture = pictureUrl + "Erntedank_Kluftingers_zweiter_Fall.jpg";
books.push(b);

b = new Book();
b.id = "7";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Seegrund. Kommissar Kluftingers dritter Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2008";
b.description = "Am Alatsee bei Füssen macht der Allgäuer Kommissar Kluftinger eine schreckliche Entdeckung – am Ufer liegt ein Taucher in einer riesigen roten Lache. Was zunächst aussieht wie Blut, entpuppt sich als eine seltene organische Substanz aus dem Bergsee. Kluftinger, der diesmal bei den Ermittlungen sehr zu seinem Missfallen weibliche Unterstützung erhält, tappt lange im Dunkeln. Der Schlüssel zur Lösung des Falles muss tief auf dem Grund des sagenumwobenen Sees liegen … Kluftingers dritter Fall von dem erfolgreichen Allgäuer Autorenduo Volker Klüpfel und Michael Kobr.";
b.isbn = "978-3492250948";
b.picture = pictureUrl + "Seegrund_Kluftingers_dritter_Fall.jpg";
books.push(b);

b = new Book();
b.id = "8";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Laienspiel. Kommissar Kluftingers vierter Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2009";
b.description = "Lodenbacher, der Chef von Kommissar Kluftinger, tobt. Ausgerechnet bei ihnen im schönen Allgäu hat sich ein Unbekannter auf der Flucht vor der österreichischen Polizei erschossen. Verdacht: Er plante einen terroristischen Anschlag. Bloß wo? Nun muss Kluftinger nicht nur mit Spezialisten des BKA, sondern auch noch mit den Kollegen aus Österreich zusammenarbeiten. Doch das ist nicht sein einziges Problem. Er soll mit seiner Frau Erika und dem Ehepaar Langhammer einen Tanzkurs absolvieren. Gleichzeitig steckt er mitten in den Endproben für die große Freilichtspiel-Inszenierung von »Wilhelm Tell« ... Kluftingers vierter Fall von dem Allgäuer Autorenduo Volker Klüpfel und Michael Kobr.";
b.isbn = "978-3492254823";
b.picture = pictureUrl + "Laienspiel_Kluftingers_vierter_Fall.jpg";
books.push(b);

b = new Book();
b.id = "9";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Rauhnacht. Kommissar Kluftingers fuenfter Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2010";
b.description = "Eigentlich sollte es für die Kluftingers ein erholsamer Kurzurlaub werden, auch wenn das Ehepaar Langhammer mit von der Partie ist: ein Winterwochenende in einem schönen Allgäuer Berghotel samt einem Live-Kriminalspiel. Doch aus dem Spiel wird blutiger Ernst, als ein Hotelgast unfreiwillig das Zeitliche segnet. Kluftinger steht vor einem Rätsel: Die Leiche befindet sich in einem von innen verschlossenen Raum. Und über Nacht löst ein Schneesturm höchste Lawinenwarnstufe aus und schneidet das Hotel von der Außenwelt ab …";
b.isbn = "978-3492259903";
b.picture = pictureUrl + "Rauhnacht_Kluftingers_fuenfter_Fall.jpg";
books.push(b);

b = new Book();
b.id = "10";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Schutzpatron. Kommissar Kluftingers sechster Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2011";
b.description = "Eine Arbeitsgruppe für die Sicherung des Altusrieder Burgschatzes, der im Allgäu gefunden wurde und jetzt nach einer weltweiten Ausstellungstour endlich wieder in die Heimat kommt – so ein Schmarrn!, denkt sich Kommissar Kluftinger, der doch gerade den mysteriösen Mord an einer alten Frau aufklären muss. Oder hat das eine gar mit dem anderen zu tun?";
b.isbn = "978-3492274838";
b.picture = pictureUrl + "Schutzpatron_Kluftingers_sechster_Fall.jpg";
books.push(b);

b = new Book();
b.id = "11";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Herzblut. Kommissar Kluftingers siebter Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2011";
b.description = "Kluftinger ist sich sicher: Bei einem anonymen Handyanruf, der ihn ausgerechnet während einer der gefürchteten Pressekonferenzen seines Chefs erreicht, wird er Zeuge eines Mordes. „Alpträume von zu viel Schweinsbraten“, tun seine Kollegen diesen Verdacht ab. Kluftinger ermittelt auf eigene Faust und findet am vermeintlichen Tatort jede Menge Blut, aber keine Leiche. Da überschlagen sich die Ereignisse: Mehrere brutale Mordfälle, anscheinend ohne Zusammenhang, erschüttern das Allgäu. Als dann doch noch der Großteil des abgängigen Toten auftaucht und Kluftinger endlich herausfindet, was all die Verbrechen verbindet, ist es fast schon zu spät ..." + 
        "Dabei steht er auch privat unter Druck: Seit Tagen leidet er unter heftigem Herzstechen und befürchtet sofort das Schlimmste. Eine demütigende Untersuchung bei Erzfeind Doktor Langhammer scheint das zu bestätigen. Doch der Kommissar ist entschlossen, das Ruder noch einmal herumzureißen. Aber ob fleisch- und kässpatzenarme Ernährung und ein Yogakurs da die richtigen Mittel sind?";
b.isbn = "978-3426511831";
b.picture = pictureUrl + "Herzblut_Kluftingers_siebter_Fall.jpg";
books.push(b);

b = new Book();
b.id = "12";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Grimmbart. Kommissar Kluftingers achter Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2014";
b.description = "Kluftingers neuer Fall führt ihn ins Schloss in Bad Grönenbach, wo ihn allerlei Merkwürdiges erwartet: Die Frau des Barons wurde nicht nur ermordet, sondern auch noch wie auf einem uralten Familienporträt hergerichtet. Auf dem Gemälde ist ein Mann mit seltsam gelben Augen zu sehen. Und der Baron verschwindet immer wieder im schlosseigenen Märchenwald. Auch privat geht es bei Kluftinger märchenhaft zu: Sein Sohn heiratet, und zur Feier haben sich die Schwiegereltern aus Japan angesagt. Zum Glück lässt Kluftingers Intimfeind Langhammer nicht lange auf sich warten, um dem Kommissar bei dieser kulturellen Herausforderung zu helfen.";
b.isbn = "978-3426511848";
b.picture = pictureUrl + "Grimmbart_Kluftingers_achter_Fall.jpg";
books.push(b);

b = new Book();
b.id = "13";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Himmelhorn: Kluftingers neuer Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2016";
b.description = "Der neunte Fall der Bestseller-Autoren Volker Klüpfel und Michael Kobr führt den Kult-Kommissar Kluftinger " +
        "in die Allgäuer Alpen, genauer gesagt auf das Himmelhorn, einen der gefährlichsten Berge des Allgäus. " +
        "Natürlich liebt Klufti die Berge - wenn sie kässpatzenförmig auf seinem Teller aufragen. Doch der neueste " +
        "Streich von Gesundheitsfetischist Langhammer befördert den Kommissar samt E-Bike tief in die Allgäuer Alpen, " +
        "wo die beiden prompt auf drei Leichen stoßen: ein bekannter Dokumentarfilmer und zwei einheimische Bergführer, " +
        "die einen Film über die Erstbesteigung des Himmelhorns drehen wollten. Wie es scheint, waren sie dem als " +
        "äußerst gefährlich geltenden Gipfel nicht gewachsen. Die Ermittlungen im Umfeld der Toten führt Klufti in " +
        "sehr abgelegene Alpentäler und zu deren starrköpfigen Bewohnern, die noch wortkarger sind als er. ";
b.isbn = "";
b.picture = pictureUrl + "Himmelhorn_Kluftingers_ neuer_Fall.jpg";
books.push(b);

b = new Book();
b.id = "14";
b.author = "Klüpfel Volker und Kobr Michael";
b.title = "Kluftinger: Kluftingers neuer Fall";
b.price = "9.90";
b.publisher = "Droemer";
b.year = "2019";
b.description = "Endlich Opa! Kommissar Kluftingers Freude über sein erstes Enkelkind wird schnell getrübt: Auf dem Friedhof entdeckt er eine Menschentraube, die ein frisch aufgehäuftes Grab umringt, darauf ein Holzkreuz – mit seinem Namen. Nach außen hin bleibt Kluftinger gelassen. Als jedoch eine Todesanzeige für ihn in der Zeitung auftaucht, sind nicht mehr nur die Kollegen alarmiert – sein ganzes Umfeld steht Kopf. Um dem Täter zuvorzukommen, muss der Kommissar tief in seine eigene Vergangenheit eintauchen. Doch die Zeit ist knapp, denn alles deutet darauf hin, dass Kluftingers angekündigter Tod unmittelbar bevorsteht.";
b.isbn = "978-3548060323";
b.picture = pictureUrl + "Kluftinger_Kluftingers_ neuer_Fall.jpg";
books.push(b);


module.exports = books;