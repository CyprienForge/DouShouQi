using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Essentials;

namespace MyTestProject
{
    /// <summary>
    /// Représente le plateau de tests
    /// Hérite de Plateau et permet de manipuler les animaux pour des tests
    /// </summary>
    public class PlateauTest : Plateau
    {
        /// <summary>
        /// Initialise une nouvelle instance de PlateauTest avec les 2 joueurs 
        /// et la version du plateau destinée à tester une ou plusieurs situations
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="idPlateau"> </param>
        public PlateauTest(Player player1, Player player2, int idPlateau)
            : base(player1, player2)
        {
            RemoveAllAnimals();
            Animal lionP1 = new Animal(player1, 7, true, false);
            Animal chatP1 = new Animal(player1, 2, false, false);
            Animal chatP2 = new Animal(player2, 2, false, false);
            Animal elephantP2 = new Animal(player2, 8, false, false);
            Animal ratP1 = new Animal(player1, 1, false, true);
            Animal ratP2 = new Animal(player2, 1, false, true);
            Animal loupP2 = new Animal(player2, 4, false, false);
            Animal loupP1 = new Animal(player1, 4, false, false);
            Animal tigreP1 = new Animal(player1, 6, true, false);
            Animal elephantP1 = new Animal(player1, 8, false, false);
            Animal tigreP2 = new Animal(player2, 6, true, false);
            Animal lionP2 = new Animal(player2, 7, true, false);
            Animal panthereP1 = new Animal(player1, 5, false, false);
            Animal panthereP2 = new Animal(player2, 5, false, false);
            Animal chienP1 = new Animal(player1, 3, false, false);
            Animal chienP2 = new Animal(player2, 3, false, false);
            if (idPlateau == 0) // Plateau par défaut
            {
                AddAnimal(1, 1, lionP1);
                AddAnimal(1, 7, tigreP1);
                AddAnimal(2, 2, loupP1);
                AddAnimal(2, 6, chatP1);
                AddAnimal(3, 1, ratP1);
                AddAnimal(3, 3, panthereP1);
                AddAnimal(3, 5, chienP1);
                AddAnimal(3, 7, elephantP1);
                AddAnimal(9, 7, lionP2);
                AddAnimal(9, 1, tigreP2);
                AddAnimal(8, 6, loupP2);
                AddAnimal(8, 2, chatP2);
                AddAnimal(7, 7, ratP2);
                AddAnimal(7, 5, panthereP2);
                AddAnimal(7, 3, chienP2);
                AddAnimal(7, 1, elephantP2);
            }
            if (idPlateau == 1) // Mouvement : Plateau pour tester les pièges (valides)
            {
                AddAnimal(1, 5, elephantP2);
                AddAnimal(2, 5, chatP1);
                AddAnimal(2, 4, ratP2);
                AddAnimal(1, 2, lionP1);
                AddAnimal(2, 3, loupP2);
                AddAnimal(7, 4, lionP1);
                AddAnimal(8, 3, ratP2);
                AddAnimal(9, 3, chatP1);
                AddAnimal(8, 5, lionP1);
                AddAnimal(9, 5, elephantP2);
            }
            if (idPlateau == 2) // Mouvement : Plateau pour tester les pièges (invalides)
            {
                AddAnimal(1, 3, chatP1);
                AddAnimal(1, 2, chatP1);
                AddAnimal(2, 3, elephantP2);
                AddAnimal(7, 4, elephantP2);
                AddAnimal(6, 4, chatP1);
                AddAnimal(8, 3, chatP1);
                AddAnimal(9, 3, ratP2);
                AddAnimal(9, 5, elephantP2);
                AddAnimal(8, 5, ratP1);
                AddAnimal(2, 5, loupP2);
                AddAnimal(1, 5, lionP1);
            }
            if (idPlateau == 3) // Mouvement : Plateau pour tester les tanières
            {
                AddAnimal(1, 3, lionP1);
                AddAnimal(1, 5, lionP1);
                AddAnimal(2, 4, lionP1);
                AddAnimal(3, 4, lionP1);
                AddAnimal(9, 3, ratP2);
                AddAnimal(9, 5, ratP2);
                AddAnimal(8, 4, ratP2);
            }
            if (idPlateau == 4) // Mouvement : Plateau pour tester les rivières 
            {
                AddAnimal(4, 1, lionP1);
                AddAnimal(3, 3, lionP1);
                AddAnimal(5, 1, tigreP1);
                AddAnimal(6, 4, ratP1);
                AddAnimal(6, 2, ratP1);
                AddAnimal(5, 4, tigreP2);
                AddAnimal(4, 7, elephantP1);
                AddAnimal(5, 7, lionP1);
                AddAnimal(5, 6, ratP1);
                AddAnimal(6, 7, lionP1);
                AddAnimal(6, 6, ratP2);
                AddAnimal(4, 5, ratP1);
                AddAnimal(3, 5, elephantP2);
                AddAnimal(8, 5, lionP1);
                AddAnimal(8, 7, elephantP2);
            }
            if (idPlateau == 5)
            {
                AddAnimal(1, 3, lionP2);
                AddAnimal(1, 5, ratP2);
                AddAnimal(2, 4, elephantP2);
                AddAnimal(8, 4, lionP1);
                AddAnimal(9, 5, ratP1);
                AddAnimal(9, 3, elephantP1);
            }
            else if(idPlateau == 6) // Victoire : Tanière du J1 occupé par le J2
            {
                AddAnimal(1, 3, lionP2);
                AddAnimal(1, 5, ratP2);
                AddAnimal(2, 4, elephantP2);
                AddAnimal(8, 4, lionP1);
                AddAnimal(9, 5, ratP1);
                AddAnimal(9, 3, elephantP1);
            }
            else if (idPlateau == 7) // Victoire : Dans une rivière 
            {
                AddAnimal(5, 5, ratP1);
                AddAnimal(6, 5, ratP2);
            }
            else if (idPlateau == 8) // Victoire : Sur terrain classique
            {
                AddAnimal(5, 4, elephantP1);
                AddAnimal(6, 4, elephantP2);
            }
            else if (idPlateau == 9) // Victoire : Après le saut vertical au dessus de la rivière 
            {
                AddAnimal(3, 5, lionP1);
                AddAnimal(7, 5, lionP2);
            }
            else if (idPlateau == 10) // Victoire : Après le saut horizontal au dessus de la rivière 
            {
                AddAnimal(5, 4, lionP1);
                AddAnimal(5, 7, lionP2);
            }
            else if (idPlateau == 11) // Victoire : Sur un piège J1
            {
                AddAnimal(3, 4, lionP1);
                AddAnimal(2, 4, lionP2);
            }
            else if (idPlateau == 12) // Victoire : Sur un piège J2
            {
                AddAnimal(8, 4, lionP1);
                AddAnimal(7, 4, lionP2);
            }
            else if (idPlateau == 13)
            {
                AddAnimal(1, 1, lionP1);
                AddAnimal(1, 4, lionP2);
            }
            else if (idPlateau == 14)
            {
                AddAnimal(1, 1, lionP2);
                AddAnimal(9, 4, lionP1);
            }
            else if (idPlateau == 15)
            {
                AddAnimal(1, 1, lionP2);
                AddAnimal(1, 2, lionP2);
            }
            else if (idPlateau == 16)
            {
                AddAnimal(1, 1, lionP1);
                AddAnimal(1, 2, lionP1);
            }
            else if (idPlateau == 17)
            {
                AddAnimal(5, 6, ratP1);
            }
            else if (idPlateau == 18) // Test en sortie de rivière pour les rats
            {
                AddAnimal(5, 5, ratP1);
                AddAnimal(5, 4, elephantP2);
            }
            else if (idPlateau == 19) // TestGameOver Tanière du Joueur 1 Occupée 
            {
                AddAnimal(5, 4, tigreP1);
                AddAnimal(7, 4, chienP2);
                AddAnimal(9, 4, chatP2);
            }
            else if (idPlateau == 20) // TestGameOver Tanière du Joueur 2 Occupée 
            {
                AddAnimal(5, 4, tigreP1);
                AddAnimal(7, 4, chienP2);
                AddAnimal(1, 4, chatP1);
            }
            else if (idPlateau == 21) // TestGameOver Tanière Non Occupée
            {
                AddAnimal(5, 4, tigreP1);
                AddAnimal(7, 4, chienP2);
                AddAnimal(8, 4, chatP2);
            }
            else if (idPlateau == 22) // TestGameOver Plus Aucun Animal Debout pour le Joueur 1
            {
                AddAnimal(5, 4, tigreP2);
            }
            else if (idPlateau == 23) // TestGameOver Plus Aucun Animal Debout pour le Joueur 2
            {
                AddAnimal(5, 4, tigreP1);
            }
            else if (idPlateau == 24)
            {
                AddAnimal(1, 1, lionP1);
                AddAnimal(1, 2, loupP1);
                AddAnimal(3, 4, elephantP1);
                AddAnimal(2, 4, ratP2);
                AddAnimal(6, 4, elephantP2);
                AddAnimal(6, 3, ratP1);
                AddAnimal(5, 4, panthereP1);
                AddAnimal(3, 6, tigreP1);
            }
            else if (idPlateau == 25) // TestIsRiverFirstLine
            {
                AddRiver(2, 1);
                AddRiver(1, 4);
                AddRiver(2, 7);
                AddRiver(8, 1);
                AddRiver(8, 4);
                AddRiver(8, 7);
                AddRiver(9, 6);
            }
            else if (idPlateau == 26) // TestIsRiverLine
            {
                AddRiver(1, 2);
                AddRiver(1, 6);
                AddRiver(9, 2);
                AddRiver(8, 7);
                AddRiver(2, 5);
            }
        }
    }
}
