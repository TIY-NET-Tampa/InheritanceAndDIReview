using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndDIReview
{
    class Program
    {

        public interface IWeapon
        {
            void DoDamage();
        }

        public class Sword : IWeapon
        {
            public void DoDamage()
            {
                Console.WriteLine("Swinging My Sword");
            }
        }
        public class Wand : IWeapon
        {
            public void DoDamage()
            {
                Console.WriteLine("Casting my Spell");
            }
        }
        public class BowAndArrow : IWeapon
        {
            public void DoDamage()
            {
                Console.WriteLine("Shotting my Bow") ;
            }
        }


        // Inheritance Example

        public interface IAttacker
        {
            void Attack();
        }


        public class SomeInt
        {
            public int MyInt { get; set; }
        }

        // everytime I do 
        /*
        var newInt = new SomeInt() {MyInt = 10};
        I want to add to Warrior.SomeInts
        ''
        ideas:
        could do get set
        method on Warrior
            
            */

        public class Warrior : IAttacker
        {
            #region MyRegion
            public List<SomeInt> _SommeInts { get; }
            public int SommeInts
            {
                set
                {
                    var temp = new SomeInt { MyInt = value };
                    this._SommeInts.Add(temp);
                }
            }

            private int myVar;

            public int HighNumber
            {
                get { return myVar; }
                set
                {
                    if (value < 100)
                    {
                        throw new Exception("Number isn't high enough");
                    }
                    myVar = value;
                }
            }
            private string rank;

            public string Rank
            {
                get { return rank; }
                set { rank = "My rank is" + value; }
            }

            private string somethingElse;

            public int HatSize
            {
                get
                {
                    var x = 9;
                    var temp = int.Parse(somethingElse);
                    return x + 9;
                }
                set { somethingElse = value.ToString(); }
            }

            public int MyProperty { get; set; }
            #endregion

            public Warrior(IWeapon w)
            {
                this.Weapon = w;
            }
            public IWeapon Weapon { get; set; }

            public void Attack()
            {
                if (Weapon == null)
                {
                    Console.WriteLine("Nothing Armed!");
                }
                else
                {
                    Weapon.DoDamage();
                }
            }
        }
        public class Knight : Warrior
        {
            public Knight():base(new Sword())
            {

            }
        }
        public class Archers : Warrior
        {
            public Archers():base(new BowAndArrow())
            {

            }
        }
        public class Wizard : Warrior
        {
            public Wizard():base(new Wand())
            {

            }
        }



        static void Main(string[] args)
        {
            //var inty = new Warrior();
            //inty.SommeInts = 6;
            //var wonky = inty._SommeInts;

            var lanceAlot = new Knight();
            var gandolf = new Wizard();
            var legalos = new Archers();
            
            var army = new List<Warrior>();
            army.Add(lanceAlot);
            army.Add(gandolf);
            army.Add(legalos);

            foreach (var soldier in army)
            {
                soldier.Attack();
            }
            Console.ReadLine();
        }
    }
}
