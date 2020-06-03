# SQA-Project-SDBIS-SIA
Automated Testing project @Centric

Change quantity of ordered products: 
- In cosul de cumparaturi este disponibila modificarea cantitatii comandate astfel ca au fost abordate doua scenarii de test: 
1 - se introduce o valoare pozitiva; 
2 - se introduce o valoare negativa. 
- Pentru cazul in care introducem valoare pozitiva, rezultatul asteptat este sa primim o alerta si ca totalul sa liniei sa fie corect. Pentru cazul in care introducem valoarea negativa, ne asteptam ca produsul sa fie sters din cosul de cumparaturi.

Remove an ordered product: 
- Am testat functionalitate de stergere a produselor compandate prin actionarea butonului de Delete. 
- Inainte de testul propriu-zis a fost adaugat un singur produs, de aceea rezultatul asteptat esta golirea cosului. 

Estimate shipping taxes: 
- In cosul de cumparaturi, este disponibila sectiunea in care sunt calculate costurile de livrare, astfel incat am testat validarea celor 3 campuri din cadrul sectiunii precum si modul in care aplicatia reactioneaza. 
- Au verficate 3 scenarii: 
1 - se introduc valori corecte pentru tara si regiune, se selecteaza prima metoda de plata sugerata si apoi se verifica daca alerta "Success" este afisata; 
2 - se introduce o tara nevalida si se verifica textul de eroare de sub camp; 
3 - se introduce tara corecta dar regiunea gresita, si, la fel, se verifica textul de eroare de sub camp.
- Pentru fiecare dintre scenarii s-a creat cate o metoda in clasa dedicata papigii "Shopping cart" pentru a utiliza valori diferite din clasa BO corespunzatoare. 
- Inainte de selectarea valorii in campul "Region" a for utilizat un obiect wait de tip Implicit pentru a oferi timp ca datele din acest drop down list sa se adapteze la tara selectata anterior.
