# Project Purple

Projet choisit : Le Platformer. 

## Table of Contents

- [Mouvements](#mouvements)
- [Collisions](#collisions)
- [Ennemis](#ennemis)
- [Progression](#progression)

## Mouvements

Chaque Niveau reçoit des évènements KeyUp et KeyDown; lorsqu'une touche correspondant à un mouvement est appuyée, on envoie l'information à l'instance de Player de ce Niveau.
J'ai crée une fonction customisée de mouvements pour PictureBox qui permet de calculer les collisions et qui renvoie un flag contenant toutes les directions de collision avec des obstacles.
Le Joueur à une gravité appliquée à lui qui augmente jusqu'à atteindre 10 pixels par seconde vers le bas.
Lorsque le joueur saute, la force de gravité est mise à 12 pixels par seconde vers le haut.

Quand le Joueur tombe dans un trou, il meurt.

## Collisions

Le Système de collisions fonctionne ainsi :
Chaque niveau à une liste d'obstacles, lorsqu'un objet est assez proche d'un obstacle, il va checker si il y a intersection de leurs Bounds.
Si le centre du Joueur se trouve à gauche par rapport à l'obstacle, le flag de collision va alors contenir la donnée "Collision à droite".
Quand le Joueur touche le sol, sa gravité est reset, pour ne pas gagner de l'inertie vers le bas.

Le Joueur check aussi (quand il est assez proche) la collision avec les ennemis; quand celui-ci n'est pas au-dessus de l'ennemi, il se prend des dégâts.
Quand le Joueur saute sur l'ennemi, il lui inflige des dégâts.

## Ennemis

Il y a deux types d'Ennemis :

Le Goomba, qui meurt quand on lui saute dessus (et donne 5 points de score) et qui tue quand on le touche de côté.

Le Koopa, qui passe en mode "Carapace" quand on lui saute dessus et qui tue quand on le touche de côté (mais pas en mode "Carapace").
Quand le Koopa est en mode "Carapace", le toucher de côté ou lui sauter dessus le pousse simplement dans la direction avant du Joueur.

## Progression

Chaque niveau contient des pièces, qui donnent 1 point de Score quand on les ramasse.

Chaque Niveau à une fin, qui est représenté par un mât avec un drapeau. Pour finir le niveau, il suffit de toucher le mât; plus haut on est sur le mât, plus on gagne de points de Score.
Après avoir fini un Niveau, Le jeu démarre le prochain niveau.
