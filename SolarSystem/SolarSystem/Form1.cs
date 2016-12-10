using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
    public partial class Form1 : Form
    {
        Brush sunBrush, mercuryBrush, venusBrush, earthBrush, marsBrush, jupiterBrush, saturnBrush, uranusBrush, neptuneBrush;
        int x, y;
        decimal acceleration = 0m;      
        Point p;      
        decimal speed = 0m;      
        float planetW, planetH ,spaceW, spaceH;
        decimal a1, a2, a3, a4, a5, a6, a7, a8, a9;
        Matrix mercuryMatrix, venusMatrix, earthMatrix, marsMatrix, jupiterMatrix, saturnMatrix, uranusMatrix, neptuneMatrix;

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetTime();
        }

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
          
            sunBrush = new TextureBrush(Properties.Resources.sun);
            mercuryBrush = new TextureBrush(Properties.Resources.mercury);
            venusBrush = new TextureBrush(Properties.Resources.venus, new Rectangle(0, 0, 252, 188));
            earthBrush = new TextureBrush(Properties.Resources.earth);
            marsBrush = new TextureBrush(Properties.Resources.mars);
            jupiterBrush = new TextureBrush(Properties.Resources.jupiter);
            saturnBrush = new TextureBrush(Properties.Resources.saturn2);
            uranusBrush = new TextureBrush(Properties.Resources.uranus);
            neptuneBrush = new TextureBrush(Properties.Resources.neptune);

            x = pictureBox1.Width / 2;
            y = pictureBox1.Height / 2;
            p = new Point(x, y);      

            planetH = pictureBox1.Height / 100 * 3;
            planetW = pictureBox1.Width / 100 * 3;

            spaceH = planetH + 10;
            spaceW = planetW + 10;



            mercuryMatrix = new Matrix();
            venusMatrix = new Matrix();
            earthMatrix = new Matrix();
            marsMatrix = new Matrix();
            jupiterMatrix = new Matrix();
            saturnMatrix = new Matrix();
            uranusMatrix = new Matrix();
            neptuneMatrix = new Matrix();

            GetTime();
        }

        private void GetTime()
        {       
            a1 = speed * 6 / 0.241m;
            a2 = speed * 6 / 0.615m;
            a3 = speed * 6 / 1.0m;
            a4 = speed * 6 / 1.88m;
            a5 = speed * 6 / 11.86m;
            a6 = speed * 6 / 29.46m;
            a7 = speed * 6 / 84.01m;
            a8 = speed * 6 / 164.79m;
            a9 = speed * 6 / 248.09m;
            speed += acceleration;

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
            g.FillEllipse(sunBrush, x - planetW*2, y - planetH*2, planetW*4, planetH*4);

            mercuryMatrix.RotateAt((float)a1, p);
            g.Transform = mercuryMatrix;
            g.FillEllipse(mercuryBrush, x - (spaceW * 1 + 20), y - (spaceH * 1+20), planetW*0.5f, planetH*0.5f);

            venusMatrix.RotateAt((float)a2, p);
            g.Transform = venusMatrix;
    
            g.FillEllipse(venusBrush, x - (spaceW * 2 + 15), y - (spaceH * 2 + 15), planetW * 0.9f, planetH * 0.9f);

            earthMatrix.RotateAt((float)a3, p);
            g.Transform = earthMatrix;
            g.FillEllipse(earthBrush, x - (spaceW * 3 + 15), y - (spaceH * 3 + 15), planetW, planetH);

            marsMatrix.RotateAt((float)a4, p);
            g.Transform = marsMatrix;
            g.FillEllipse(marsBrush, x - (spaceW * 4), y - (spaceH * 4), planetW*0.5f, planetH*0.5f);

            jupiterMatrix.RotateAt((float)a5, p);
            g.Transform = jupiterMatrix;
            g.FillEllipse(jupiterBrush, x - (spaceW * 5 + 15), y - (spaceH * 5 + 15), planetW*2, planetH*2);

            saturnMatrix.RotateAt((float)a6, p);
            g.Transform = saturnMatrix;
            g.FillEllipse(saturnBrush, x - (spaceW * 6 + 20), y - (spaceH * 6 + 20), planetW * 1.75f, planetH * 1.75f);
            //g.DrawImage(Properties.Resources.saturn, x - (spaceW * 6 + 20), y - (spaceH * 6 + 20), planetW * 3.5f, planetH * 1.75f);

            uranusMatrix.RotateAt((float)a7, p);
            g.Transform = uranusMatrix;
            g.FillEllipse(uranusBrush, x - (spaceW * 7 +10 ), y - (spaceH * 7 +10 ), planetW*1.25f, planetH*1.25f);

            neptuneMatrix.RotateAt((float)a8, p);
            g.Transform = neptuneMatrix;
            g.FillEllipse(neptuneBrush, x - (spaceW * 7.2f + 30), y - (spaceH * 7.2f + 30), planetW*1.25f, planetH*1.25f);

            mercuryMatrix.Reset();
            venusMatrix.Reset();
            earthMatrix.Reset();
            marsMatrix.Reset();
            jupiterMatrix.Reset();
            saturnMatrix.Reset();
            uranusMatrix.Reset();
            neptuneMatrix.Reset();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            acceleration = numericUpDown1.Value/10;
            numericUpDown1.Value = acceleration*10;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Sun":
                    {
                        label1.Text = "* At its centre the Sun reaches temperatures of 15 million °C.\n* The Sun is all the colours mixed together, this appears white to our eyes.\n* The Sun is mostly composed of hydrogen(70 %) and Helium (28 %).\n* The Sun is a main - sequence G2V star(or Yellow Dwarf).\n* The Sun is 4.6 billion years old.\n* The Sun is 109 times wider than the Earth and 330, 000 times as massive.";
                        break;
                    }
                case "Mercury":
                    {
                        label1.Text = "* Mercury does not have any moons or rings.\n* Your weight on Mercury would be 38 % of your weight on Earth.\n *A day on the surface of Mercury lasts 176 Earth days. \n* A year on Mercury takes 88 Earth days.\n* Mercury has a diameter of 4,879 km, making it the smallest planet.\n* It’s not known who discovered Mercury.";
                        break;
                    }
                case "Venus":
                    {
                        label1.Text = "* Venus does not have any moons or rings.\n* Venus is nearly as big as the Earth with a diameter of 12,104 km.\n* Venus is thought to be made up of a central iron core, rocky mantle and silicate crust.\n* A day on the surface of Venus(solar day) would appear to take 117 Earth days.\n* A year on Venus takes 225 Earth days.\n* The surface temperature on Venus can reach 471 °C.";
                        break;
                    }
                case "Earth":
                    {
                        label1.Text = "Earth is the third planet from the Sun and is the largest of the terrestrial planets. The Earth is the only planet in our solar system not to be named after a Greek or Roman deity. The Earth was formed approximately 4.54 billion years ago and is the only known planet to support life.";
                        break;
                    }
                case "Mars":
                    {
                        label1.Text = "* Mars and Earth have approximately the same landmass.\n* Mars is home to the tallest mountain in the solar system.\n* Only 18 missions to Mars have been successful.\n* Mars has the largest dust storms in the solar system.";
                        break;
                    }
                case "Jupiter":
                    {
                        label1.Text = "* Jupiter is the fourth brightest object in the solar system. Only the Sun, Moon and Venus are brighter.It is one of five planets visible to the naked eye from Earth.\n* Jupiter has the shortest day of all the planets. It turns on its axis once every 9 hours and 55 minutes.The rapid rotation flattens the planet slightly, giving it an oblate shape.\n* Jupiter orbits the Sun once every 11.8 Earth years.\n* The Great Red Spot is a huge storm on Jupiter. It has raged for at least 350 years.It is so large that three Earths could fit inside it.";
                        break;
                    }
                case "Saturn":
                    {
                        label1.Text = "* Saturn can be seen with the naked eye. It is the fifth brightest object in the solar system and is also easily studied through binoculars or a small telescope.\n* Saturn is the flattest planet. Its polar diameter is 90 % of its equatorial diameter, this is due to its low density and fast rotation.Saturn turns on its axis once every 10 hours and 34 minutes giving it the second - shortest day of any of the solar system’s planets.\n* Saturn orbits the Sun once every 29.4 Earth years. Its slow movement against the backdrop of stars earned it the nickname of “Lubadsagush” from the ancient Assyrians.The name means “oldest of the old”.\n* Saturn has 150 moons and smaller moonlets. All are frozen worlds. The largest moons are Titan and Rhea.Enceladus appears to have an ocean below its frozen surface.\n* Four spacecraft have visited Saturn. Pioneer 11, Voyager 1 and 2, and the Cassini - Huygens mission have all studied the planet. Cassini continues to orbit Saturn, sending back a wealth of data about the planet, its moons, and rings.";
                        break;
                    }
                case "Uranus":
                    {
                        label1.Text = "* Uranus makes one trip around the Sun every 84 Earth years.\n* Uranus is often referred to as an “ice giant” planet.\n* Uranus hits the coldest temperatures of any planet. With minimum atmospheric temperature of - 224°C Uranus is nearly coldest planet in the solar system.While Neptune doesn’t get as cold as Uranus it is on average colder. The upper atmosphere of Uranus is covered by a methane haze which hides the storms that take place in the cloud decks.\n* Uranus has two sets of very thin dark coloured rings.\n* Only one spacecraft has flown by Uranus. In 1986, the Voyager 2 spacecraft swept past the planet at a distance of 81,500 km.It returned the first close - up images of the planet, its moons, and rings.";
                        break;
                    }
                case "Neptune":
                    {
                        label1.Text = "* Neptune is the smallest of the ice giants.\n* Neptune has a very active climate. Large storms whirl through its upper atmosphere, and high-speed winds track around the planet at up 600 meters per second.One of the largest storms ever seen was recorded in 1989.It was called the Great Dark Spot. It lasted about five years.\n* Neptune has 14 moons. The most interesting moon is Triton, a frozen world that is spewing nitrogen ice and dust particles out from below its surface.It was likely captured by the gravitational pull of Neptune.It is probably the coldest world in the solar system.\n* Only one spacecraft has flown by Neptune. In 1989, the Voyager 2 spacecraft swept past the planet.It returned the first close - up images of the Neptune system.The NASA/ ESA Hubble Space Telescope has also studied this planet, as have a number of ground-based telescopes.";
                        break;
                    }
            }
        }
    }
}
