using System;
using System.Collections.Generic;
using System.Text;

namespace CarreMagique
{
    public class NomFichier
    {
        private int iNombre;
        private int iOccurence;
        private string sPrefixe;
        private string sTypeFichierCourt;
        private string sTypeFichierLib;
        private string sTypeFichierPath;
        private string sSuffixe;

        public string SPrefixe { get => sPrefixe; set => sPrefixe = value; }
        public int INombre { get => iNombre; set => iNombre = value; }
        public string STypeFichierCourt { get => sTypeFichierCourt; set => sTypeFichierCourt = value; }
        public string STypeFichierLib { get => sTypeFichierLib; set => sTypeFichierLib = value; }
        public string STypeFichierPath { get => sTypeFichierPath; set => sTypeFichierPath = value; }
        public int IOccurence { get => iOccurence; set => iOccurence = value; }
        public string SSuffixe { get => sSuffixe; set => sSuffixe = value; }

        public NomFichier(string s)
        {
            sPrefixe = "cm";
            iNombre = 0;
            sTypeFichierCourt = "";
            sTypeFichierLib = "";
            sTypeFichierPath = @"";
            iOccurence = 0;
            sSuffixe = s;
        }

        public void getValues(string p, int n, string tFC, string tFL, string tFP, int o, string s)
        {
            sPrefixe = "cm";
            iNombre = 0;
            sTypeFichierCourt = "";
            sTypeFichierLib = "";
            sTypeFichierPath = @"";
            iOccurence = 0;
            sSuffixe = ".txt";
        }
        public override string ToString()
        {
            string res = sPrefixe + iNombre.ToString() + sTypeFichierCourt + iOccurence + sSuffixe;
            return res;
        }
        public string DonneNomFichierComplet()
        {
            string res = sPrefixe + iNombre.ToString() + sTypeFichierCourt + iOccurence + sSuffixe;
            return res;
        }
        public bool EstMemeNomFichier(string nomFichier)
        {
            if (this.ToString() == nomFichier)
            {
                Console.WriteLine("sont identiques");
                return true;
            }
            else
            {
                Console.WriteLine("sont différentes");
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            NomFichier nf = obj as NomFichier;
            if (nf == null)
                return false;
            return sPrefixe == nf.SPrefixe
                && INombre == nf.INombre
                && STypeFichierCourt == nf.STypeFichierCourt
                && STypeFichierLib == nf.STypeFichierLib
                && STypeFichierPath == nf.STypeFichierPath
                && IOccurence == nf.IOccurence
                && SSuffixe == nf.SSuffixe;
        }
        public void DecompositionNomFichier( string sFichierAvecExtension)
        {/*
            fonction ventiler le nom du fichier dans les différentes propriétés 
            de l'objet de type NomFichier selon une structure 
            préfixe en lettres
            taille carré magique en chiffres
            type de carré magique en lettres
            occurrence en chiffres
            suffixe selon échantillon
             */
            Uti.Info("NomFichier", "DecompositionNomFichier", "");
            int iPosBarre = sFichierAvecExtension.LastIndexOf(@"\");
            string sFich = sFichierAvecExtension.Substring(iPosBarre, sFichierAvecExtension.Length - (iPosBarre));
            int iPosPoint = sFich.LastIndexOf('.');
            string sExtension = sFich.Substring(iPosPoint, sFich.Length - iPosPoint);
            char[] tabChar = sFich.ToCharArray();
            int iPos;            
            string sVal = "";
            int iVal;
            // reconnaissance de l'extension
            if (sExtension == ".txt")
            {
                SSuffixe = ".txt";
            }
            else
            {
                SSuffixe = ".json";
            }
            iPos = 0;
            int i = iPos;
            // éviter les caractères de séparation de dossiers 
            while (!Char.IsLetterOrDigit(tabChar[i]))
            {
                i++;
            }
            // reconnaissance préfixe "cm"
            while (!Char.IsDigit(tabChar[i]))
            {
                sVal += tabChar[i];
                i++;
            }
            sPrefixe = sVal;
            // reconnaissance du nombre (taille du carré magique)
            sVal = "";
            while (i < tabChar.Length)// commence après "cm"
            {
                if (Char.IsDigit(tabChar[i]))
                {
                    sVal += tabChar[i];
                }
                else
                {
                    break;// pour sortir à la première lettre rencontrée
                }
                i++;
            }
            if (int.TryParse(sVal, out iVal))
            {

                iNombre = iVal;
            }
            else
            {

                Console.WriteLine("Conversion impossible");
            }
            INombre = iVal;
            // reconnaissance du type de fichier résolu ou en cours
            sVal = "";
            while (i < tabChar.Length)// commence après le nombre
            {
                if (!Char.IsDigit(tabChar[i]))
                {
                    sVal += tabChar[i];
                }
                else
                {
                    break;// pour sortir au premier chiffre rencontré
                }
                i++;
            }
            if (sVal == "ec")
            {
                sTypeFichierCourt = "ec";
                sTypeFichierLib = "en cours";
                sTypeFichierPath =@"en-cours\" ;
            }
            else
            {
                sTypeFichierCourt = "r";
                sTypeFichierLib = "résolus";
                sTypeFichierPath = @"resolus\";
            }
            // reconnaissance de l'occurrence
            sVal = "";
            while (i < tabChar.Length)// commence après "cm"
            {
                if (Char.IsDigit(tabChar[i]))
                {
                    sVal += tabChar[i];
                }
                else
                {
                    break;// pour sortir à la première lettre rencontrée
                }
                i++;
            }
            if (int.TryParse(sVal, out iVal))
            {
                iOccurence = iVal;
            }
            else
            {
                Console.WriteLine("Conversion impossible");
            }
        }
        public void RAZNomFichier()
        {
            sPrefixe = "cm";
            iNombre = 0;
            iOccurence = 0;
            sSuffixe = "";
            sTypeFichierCourt = "";
            sTypeFichierLib = "";
            sTypeFichierPath = @"";
        }
        public void Copier(NomFichier nf)
        {
            // nf le fichier dont les propriétés de  l'instance
            // sont copiés dans les propriétés de l'objet appelant
             sPrefixe =nf.sPrefixe;
            iNombre= nf.iNombre ;
             sTypeFichierCourt =nf.sTypeFichierCourt;
            sTypeFichierLib = nf.sTypeFichierLib;
            sTypeFichierPath= nf.sTypeFichierPath ;
             iOccurence =nf.iOccurence;
            sSuffixe =nf.sSuffixe ;
        }
        public override int GetHashCode()
        {
            return sPrefixe.GetHashCode() *
                INombre.GetHashCode() *
                STypeFichierCourt.GetHashCode() *
                STypeFichierLib.GetHashCode() *
                STypeFichierPath.GetHashCode() *
                IOccurence.GetHashCode() *
                SSuffixe.GetHashCode();
        }
    }

}
