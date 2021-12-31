using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPN_16_Sifreleme
{
    [TestFixture] // bu ifade bize bu sınıfın bir test sınıfı olduğunu ifade etmektedir
    class nunitTest
    {
        nunitTest eD = new nunitTest(); // burada EncryptionDecryption sınıfımızdan bir nesne oluşturduk

        [Test] //bu ifade bize bu metodun test metodu olduğunu ifade etmektedir
        public void StringToBinary() //StringToBinary test metodumuz
        {
            string sonuc = eD.StringToBinary("na"); //StringToBinary methoduna değerimizi parametre olarak geçirdik, ve EncryptionDecryption sınıfının metodunu çağırdık
            Assert.AreEqual("0110111001100001", sonuc); //ilk parametre 2. parametre ile aynı ise methodumuz doğru çalışıyordur ve test başarılıdır
        }

        private string StringToBinary(string v)
        {
            throw new NotImplementedException();
        }

        [Test] //bu ifade bize bu metodun test metodu olduğunu ifade etmektedir
        //
        public void BinaryToString() //BinaryToString test metodumuz
        {
            string sonuc = eD.BinaryToString("0110111001100001"); //BinaryToString methoduna değerimizi parametre olarak geçirdik, ve EncryptionDecryption sınıfının metodunu çağırdık
            Assert.AreEqual("na", sonuc); //ilk parametre 2. parametre ile aynı ise methodumuz doğru çalışıyordur ve test başarılıdır
        }

        private string BinaryToString(string v)
        {
            throw new NotImplementedException();
        }

        [Test] //bu ifade bize bu metodun test metodu olduğunu ifade etmektedir
        public void SPN_encryption() //metin test metodumuz
        {
            string sonuc = eD.SPN_encryption("adana"); //metin methoduna değerimizi parametre olarak geçirdik, ve EncryptionDecryption sınıfının metodunu çağırdık
            Assert.AreEqual("101011100110001100101110011100111010111101000011", sonuc); //ilk parametre(mutluyum kelimesinin spn16 ile şifrelenmiş binary değeri) 2. parametre ile aynı ise şifreleme methodumuz doğru çalışıyordur ve test başarılıdır
        }

        private string SPN_encryption(string v)
        {
            throw new NotImplementedException();
        }

        [Test] //bu ifade bize bu metodun test metodu olduğunu ifade etmektedir
        public void metinCoz() //metinCoz test metodumuz
        {
            string sonuc = eD.metinCoz("1110111001101101000011000110101101001110010011110000111001101111"); //metinCoz methoduna değerimizi(mutluyum kelimesinin spn16 ile şifrelenmiş binary değeri) parametre olarak geçirdik, ve EncryptionDecryption sınıfının metodunu çağırdık
            Assert.AreEqual("0110110101110101011101000110110001110101011110010111010101101101", sonuc); //ilk parametre(mutluyum kelimesinin binary değeri) 2. parametre ile aynı ise şifreleme methodumuz doğru çalışıyordur ve test başarılıdır
        }

        private string metinCoz(string v)
        {
            throw new NotImplementedException();
        }

        [Test] //bu ifade bize bu metodun test metodu olduğunu ifade etmektedir
        public void encrypt() //SHA_256_Encrypting test metodumuz
        {
            string sonuc = eD.encrypt("izmir"); //SHA_256_Encrypting methoduna değerimizi parametre olarak geçirdik, ve EncryptionDecryption sınıfının metodunu çağırdık
            Assert.AreEqual("f3698e349001815961ee800a678db2d55d8f3b01e1ee7a402451c5b189cb3fc9", sonuc); //ilk parametre(mutluyum kelimesinin sha256 ile şifrelenmiş hali) 2. parametre ile aynı ise şifreleme methodumuz doğru çalışıyordur ve test başarılıdır
        }

        private string encrypt(string v)
        {
            throw new NotImplementedException();
        }
    }
}
