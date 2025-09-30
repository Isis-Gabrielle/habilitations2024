using habilitations2024.model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les profils
    /// </summary>
    public class ProfilAccess
    {
        /// <summary>
        /// Instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public ProfilAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les profils
        /// </summary>
        /// <returns>liste des profils</returns>
        public List<Profil> GetLesProfils()
        {
            List<Profil> lesProfils = new List<Profil>();
            if (access.Manager != null)
            {
                string req = "select * from profil order by nom;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        Log.Debug("ProfilAccess.GetLesProfils : nombre d'enregistrements récupérés = {Count}", records.Count);
                        foreach (Object[] record in records)
                        {
                            Log.Debug("ProfilAccess.GetLesProfils : idprofil={Idprofil}, nom={Nom}",
                       record[0], record[1]);

                            Profil profil = new Profil((int)record[0], (string)record[1]);
                            lesProfils.Add(profil);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "ProfilAccess.GetLesProfils : catch erreur = {Erreur}, req={Requete}", ex.Message, req);
                    Environment.Exit(0);
                }
            }
            return lesProfils;
        }

    }
}
