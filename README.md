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
Au final je pense que je ne le ferai pas.

Le programme intègre une version interactive ou le joueur procède à des 
permutations. Le jeu devient rapidement rébarbatif. Il épargne juste à 
l'utilisateur le travail de calcul des sommes croissant selon la taille 
du carré.
A noter que les fichiers sauvegardés sont en fichier texte ou json au choix, 
et réparti en deux dossiers 'en-cours' et 'resolus'.

*** Recours à la classe Uti

Il s'agit d'une classe fourre tout que j'alimente pour pouvoir m'en 
resservir dans d'autre projets
