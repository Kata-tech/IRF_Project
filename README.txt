A szoftverem egy utaz�si iroda programja. 
A program megkapja az adott megrendel�seket egy csv f�jlban. Ezeket egy list�ban t�rolja a program. Ezek az adatok soronk�nt: telep�l�s neve, hotel neve, csomag sorsz�ma, �jszak�k sz�ma, f�r�helyek sz�ma, forint f�/�j, kedvezm�ny.
A c�g hozz�adhat ehhez a list�hoz �j megrendel�seket. Ilyenkor az �rlapon tal�lhat� mez�ket kit�lti (ezt ellen�rizz�k Unit Testtel), �s ezeket a program string m�trixban t�rolja. 
Az illeszked�si minta adaptere seg�ts�g�vel a csv f�jlb�l bek�rt list�t �ttudjuk alak�tani string m�trixba, �gy hozz�tudjuk adni az �jabb adatokat, majd a v�gleges t�mb�t visszatudjuk alak�tani list�v�. Miut�n megvan az eg�sz lista, kisz�moljuk az �sszesen fizetend� p�nz�sszeget az adott csomagokhoz.
Az �sszes adatot a kisz�molt p�nz�sszeggel export�ljuk excelbe, form�zottan. 
A v�g�n ki�rja a szoftver, hogy melyik vend�g, h�ny forinttal tartozik a c�gnek.
Miut�n ezt ki�rta, ha 30 m�sodperc m�lva nem kattintunk semmire, akkor visszavisz az eredeti kezd�oldalra (ehhez haszn�lom a Timert).  



