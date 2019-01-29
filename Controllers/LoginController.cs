using System;
using System.Collections.Generic;
using System.Diagnostics; //Permet de Tester les variables
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjetJB2.Models;

namespace ProjetJB2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /*Méthode de Connexion*/
        [HttpPost]
        public ActionResult SignIn(string login, string password, string stat)
        {
            if (login != "" && password != "")  //Vérification que les variables ne soient pas vides
            {
                if (stat == "Student")
                {   //Contrôle du statut (Etudiant/Enseignant)

                }
                else
                {   //Statut == "Teacher"

                }

                /*foreach(int variable in users)	//Parcours des données
				{
					if() {	//Comparaison entre les données et les informations saisies
					}
					else {
						//Message d'Erreur
					}
				}*/

            }
            return View("../Home/Index");   //Redirection vers la page d'accueil
        }

        /*Méthode de Déconnexion*/
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}