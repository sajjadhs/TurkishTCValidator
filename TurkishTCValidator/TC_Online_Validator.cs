using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkishTCValidator
{
    public class TC_Online_Validator
    {
        public delegate void ValidationResult(bool result, object yourSentObject);
        private tr.gov.nvi.tckimlik.KPSPublic KPSPublic;
        private tr.gov.nvi.tckimlik1.KPSPublicYabanciDogrula KPSPublicYabanciDogrula;
        public event ValidationResult OnValidationResult;
        public TC_Online_Validator()
        {
            KPSPublic = new tr.gov.nvi.tckimlik.KPSPublic();
            KPSPublicYabanciDogrula = new tr.gov.nvi.tckimlik1.KPSPublicYabanciDogrula();
            KPSPublicYabanciDogrula.YabanciKimlikNoDogrulaCompleted += KPSPublicYabanciDogrula_YabanciKimlikNoDogrulaCompleted;
            KPSPublic.TCKimlikNoDogrulaCompleted += KPSPublic_TCKimlikNoDogrulaCompleted;
        }

        private void KPSPublicYabanciDogrula_YabanciKimlikNoDogrulaCompleted(object sender, tr.gov.nvi.tckimlik1.YabanciKimlikNoDogrulaCompletedEventArgs e)
        {
            OnValidationResult?.Invoke(e.Result, e.UserState);
        }

        /// <summary>
        /// this will call online id validation api for native people and fires result
        /// In order to get result you should listen to this event: <b>OnValidationResult </b>
        /// </summary>
        /// <param name="TC"></param>
        /// <param name="Name"></param>
        /// <param name="LastName"></param>
        /// <param name="BirthYear"></param>
        /// <param name="callbackinput">any object to get it in result, maybe name or some numbers or any class type</param>
        public void CallValidator(long TC, string Name, string LastName, int BirthYear, object callbackinput = null)
        {
            KPSPublic.TCKimlikNoDogrulaAsync(TC, Name, LastName, BirthYear, callbackinput);
        }

        private void KPSPublic_TCKimlikNoDogrulaCompleted(object sender, tr.gov.nvi.tckimlik.TCKimlikNoDogrulaCompletedEventArgs e)
        {
            OnValidationResult?.Invoke(e.Result, e.UserState);
        }

        /// <summary>
        /// this will call validate id number of native people,(blocks thread until retur result)
        /// </summary>
        /// <param name="TC"></param>
        /// <param name="Name"></param>
        /// <param name="LastName"></param>
        /// <param name="BirthYear"></param>
        /// <returns></returns>
        public bool Validate(long TC, string Name, string LastName, int BirthYear)
        {
            return KPSPublic.TCKimlikNoDogrula(TC, Name, LastName, BirthYear);
        }

        /// <summary>
        /// this will validates id number for Foreigners
        /// </summary>
        /// <param name="TC"></param>
        /// <param name="Name"></param>
        /// <param name="LastName"></param>
        /// <param name="BirthYear"></param>
        /// <param name="BirthMonth">is optional</param>
        /// <param name="BirthDay">is optional</param>
        /// <returns></returns>
        public bool ValidateForeigner(long TC, string Name, string LastName, int BirthYear, int BirthMonth, int BirthDay)
        {
            return KPSPublicYabanciDogrula.YabanciKimlikNoDogrula(TC, Name, LastName, BirthDay, BirthMonth, BirthYear);
        }

        /// <summary>
        /// this overload will call online validator for Foreigners and will fire the result
        /// In order to get result you should listen to this event: <b>OnValidationResult </b>
        /// </summary>
        /// <param name="TC"></param>
        /// <param name="Name"></param>
        /// <param name="LastName"></param>
        /// <param name="BirthYear"></param>
        /// <param name="BirthMonth">is optional</param>
        /// <param name="BirthDay">is optional</param>
        /// <param name="callbackinput">any object to get it in result, maybe name or some numbers or any class type</param>
        public void CallValidatorForeigner(long TC, string Name, string LastName, int BirthYear, int BirthMonth, int BirthDay, object callbackinput = null)
        {
            KPSPublicYabanciDogrula.YabanciKimlikNoDogrulaAsync(TC, Name, LastName, BirthDay, BirthMonth, BirthYear, callbackinput);
        }
    }
}
