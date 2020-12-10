A szoftverem egy utazási iroda programja. 
A program megkapja az adott megrendeléseket egy csv fájlban. Ezeket egy listában tárolja a program. Ezek az adatok soronként: település neve, hotel neve, csomag sorszáma, éjszakák száma, férõhelyek száma, forint fõ/éj, kedvezmény.
A cég hozzáadhat ehhez a listához új megrendeléseket. Ilyenkor az ûrlapon található mezõket kitölti (ezt ellenõrizzük Unit Testtel), és ezeket a program string mátrixban tárolja. 
Az illeszkedési minta adaptere segítségével a csv fájlból bekért listát áttudjuk alakítani string mátrixba, így hozzátudjuk adni az újabb adatokat, majd a végleges tömböt visszatudjuk alakítani listává. Miután megvan az egész lista, kiszámoljuk az összesen fizetendõ pénzösszeget az adott csomagokhoz.
Az összes adatot a kiszámolt pénzösszeggel exportáljuk excelbe, formázottan. 
A végén kiírja a szoftver, hogy melyik vendég, hány forinttal tartozik a cégnek.
Miután ezt kiírta, ha 30 másodperc múlva nem kattintunk semmire, akkor visszavisz az eredeti kezdõoldalra (ehhez használom a Timert).  



