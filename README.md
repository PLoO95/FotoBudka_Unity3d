# FotoBudka_Unity3d
Zadanie rekrutacyjne

Modele 
Ładują się z folderu Resources/Input , foramt prefab
Zdjęcia zapisują się do folderu StreamingAssets/Output, dzięki temu można wyeksportować aplikacje i pobierać zrobione zdjęcia bez edytora.
Aby zapisywać zdjęcia w Resources/Output wystraczy zamienić ścieżkę w ScreenShoot na Application.path + "/Resources/Output/". Program sam stworzy folder.

Sterowanie:

GUI:
Next - Następny Model
Back - Poprzedni Model
Photo - Robi zdjęcie do folderu StreamingAssets/Output/xxx.png

Input:
Naciśnięty lewy przycisk myszy po naciśnięciu przesówa obiekt lewo prawo w zależności od pozycji myszki.
Rolka myszki reguluje zoom kamery.
Naciśnięta rolka myszki reguluje pozycje kamery góra/dól lewo/prawo w zależności od położenia myszki.
Naciśnięty prawy przycisk reguluje rotacje kamery gora/dol w zależności od położenia myszki.
Po puszczeniu ww. klawiszy akcja jest zatrzymana.

Wersja Unity 2019.2.6f1
Język: C#
