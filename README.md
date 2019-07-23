# CarreMagique
programme interactif de jeu de carré magique
commencé le 06/06/2019
*** implémenté
Le programme fonctionne en mode console avec un damier de cellules.
Les cellules contiennes des entiers (coordonnées et valeur).
Il aurait été possible de ne manipuler que des entiers plutôt que des 
objets. Mais il aurait alors été impossible de conserver les coordonnées 
de chaque valeur dans le damier à tout moment du programme.
J'ai souhaité à  des fins pédagogiques manipuler des objets et ai voulu 
envisager une éventuelle implémentation graphique du programme.

Le programme intègre une version interactive ou le joueur procède à des 
permutations. Le jeu devient rapidement rébarbatif. Il épargne juste à 
l'utilisateur le travail de calcul des sommes croisant selon la taille 
du carré.

*** à implémenter à la rigueur 

 une option d'autorésolution du carré magique.
 il faudrait un algorithme qui permette de limiter les permutations sur des combinaisons inutiles

*** à implémenter
doter le programme d'une persistance des données avec la sauvegarde dans un fichier texte
ou de format json des valeurs du damier et du nombre du carre magique.

la persistance des données va être implémentée au moyen d'une classe 
complémentaire nommée Persistance pour avoir une application ou les 
classes ne concentrent pas tout le bagage de fonctions hétérogènes.
Le principe est d'avoir des classes plus nombreuses avec un répertoire 
de méthodes moins nombreuses plutôt que peu de classe avec des fonctions 
trop nombreuses.


*** Recours à la classe Uti

Il s'agit d'une classe fourre tout que j'alimente pour pouvoir m'en 
resservir dans d'autre projets
