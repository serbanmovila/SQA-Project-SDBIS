# SQA-Project-SDBIS-SIA
Automated Testing project @Centric

AddProductToCartTest 
- presupune testarea adaugarii de produse in cos de pe pagina produselor prin actionarea butonului de 'Add to cart' 
- adaugarea in cos din pagina de prezentare a produsului prin completarea cantitatii si apoi actionarea butonului 'Add to cart'.
- in cazut adaugarii in cos din lista de produse a fost utilizat Thread.Sleep pentru a astepta animatia de aparitie a mesajului de alerta.

AddToProductReviewTest 
presupune testarea a doua scenarii prin cele doua metode de test:
  - adaugarea cu succes a unui review,
  - eroare la adaugarea unui review. Eroarea apare atunci cand textul review-ului are maiputin de 25 de caractere.

AddToWishList
presupune testarea scenariului in care se actioneaza butonul de 'Add to wish list' si produsul est adaugat in Wish List.

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

LoginTest
- Se testeaza functionalitatea modulului de login, cu ajutorul claselor LoginBO (ce contine email si parola) si LoginPage (ce contine ruta catre formularul de login, identificarea campurilor de email si parola si metoda ce introduce datele, pe baza datelor din BO).
- Se folosesc wait-uri explicite pentru fiecare element ce necesita confirmarea afisarii elementelor cerute

RegisterTest
- Se testeaza functionalitatea modulului de register, cu ajutorul claselor RegisterBO (ce contine datele necesare pentru inregistrare) si RegisterPage (ce contine ruta catre formularul de inregistrare, identificarea campurilor necesare si metoda ce introduce datele din BO).
- Daca datele prezente in BO sunt de tip null sau "", atunci nu se completeaza campul respectiv
- Se folosesc wait-uri explicite pentru fiecare element ce necesita confirmarea afisarii diferitelor elemente

ChangeAddressTest
- Se testeaza functionalitatea modulului de schimbare adresa, in felul urmator: se logheaza utilizatorul, se acceseaza pagina de change address, se modifica datele (se fac "" si apoi SendKeys, doar cele care nu sunt null; cele care sunt null, raman neschimbate) si se verifica daca schimbarea a avut loc cu succes (daca se modifica URL-ul, sau daca se ramane pe aceeasi pagina, cu mesaj de eroare)
- Acest test include si testul de logare
- Include clasa ChangeAddressBO, care contine, similar cu RegisterBO, toate datele necesare pentru schimbarea adresei.
- Se folosesc wait-uri explicite pentru fiecare element ce necesita confirmarea afisarii elementelor necesare
- Ruta catre pagina de schimbare adresa se imparte in 3 pasi: 
  1. Login (implementat anterior)
  2. My Account (clasa MyAccountPage)- din utilizatorul logat se ajunge in panoul utilizator
  3. Address Book (clasa AddressPage) - se da click pe Address Book, apoi Edit
- In final, clasa ChangeAddressPage contine metoda necesara modificarii si update-ului adresei utilizatorului
  



