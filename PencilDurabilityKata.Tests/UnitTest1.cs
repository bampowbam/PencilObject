using NUnit.Framework;
using PencilDurabilityKata;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Writing_Test()
        {
            Pencil _pencil = new Pencil(4000, 3000, 1000);
            _pencil.Write("She sells sea shells");

            Assert.AreSame("She sells sea shells", _pencil.FullText);
        }

        [Test]
        public void Point_Degregation_Test()
        {
            Pencil _pencil = new Pencil(4000, 20, 1000);
            _pencil.Write("She sells sea shells");

            Assert.AreEqual(2, _pencil.PointDegradation);
        }

        [Test]
        public void Sharpen_Degregation_Test()
        {
            Pencil _pencil = new Pencil(4000, 20, 1000);
            _pencil.Write("She sells sea shells");

            _pencil.Sharpen();

            Assert.AreEqual(20, _pencil.PointDegradation);
        }
        [Test]
        public void Sharpen_PencilLength_Test()
        {
            Pencil _pencil = new Pencil(4000, 20, 1000);
            _pencil.Write("She sells sea shells");

            _pencil.Sharpen();

            Assert.AreEqual(3999, _pencil.PencilLength);
        }
        [Test]
        public void Erase_Test()
        {
            Pencil _pencil = new Pencil(4000, 1000, 1000);
            _pencil.Write("How much wood would a woodchuck chuck if a woodchuck could chuck wood?");

            _pencil.Erase("chuck");

            Assert.AreEqual("How much wood would a woodchuck chuck if a woodchuck could       wood?", _pencil.FullText);
        }
        [Test]
        public void Erase_Degregation_Test()
        {
            Pencil _pencil = new Pencil(4000, 1000, 3);
            _pencil.Write("How much wood would a woodchuck chuck if a woodchuck could chuck wood?");

            _pencil.Erase("chuck");

            Assert.AreEqual(0, _pencil.EraseDegradation);
        }
        [Test]
        public void Edit_Test()
        {
            Pencil _pencil = new Pencil(4000, 1000, 300);
            _pencil.Write("An onion a day keeps the doctor away");

            _pencil.Erase("onion");

            _pencil.Edit("artichoke");
            Assert.AreEqual("An artich@k@ay keeps the doctor away", _pencil.FullText);
        }
    }
}