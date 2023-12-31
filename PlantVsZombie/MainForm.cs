using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PlantVsZombie.GlobalVariables;
using PlantVsZombie.Droppables;
using PlantVsZombie.Plants;
using PlantVsZombie.Components;
using PlantVsZombie.Zombies;
using PlantVsZombie.Props;

namespace PlantVsZombie
{
    public partial class MainForm : Form
    {
        private Random random = new Random();

        private List<List<Color>> colorTiles = new List<List<Color>>()
        {
            new List<Color>
            {
                Color.FromArgb(6, 174, 26),
                Color.FromArgb(6, 144, 22)
            },
            new List<Color>
            {
                Color.FromArgb(6, 202, 42),
                Color.FromArgb(6, 174, 26)
            }
        };

        private List<Plant> plantList;

        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            plantList = new List<Plant>()
            {
                new Sunflower(picBoxGameArea, this)
                {
                    Index = 0
                },
                new PeaShooter(picBoxGameArea, this)
                {
                    Index = 1
                },
                new IceShooter(picBoxGameArea, this)
                {
                    Index = 2
                },
                new WallNut(picBoxGameArea, this)
                {
                    Index = 3
                }
            };

            LoadGameArea();
            LoadPlantList();
            LoadSunCount();

            timerRandomSun.Start();
            timerRandomZombie.Start();
        }

        private void LoadPlantList()
        {
            for (int i = 0; i < plantList.Count; i++)
            {
                Plant plant = plantList[i];
                //var plantCard = new PlantCardLayout()
                //{
                //    plantIndex = plant.Index,
                //    plantName = plant.Name,
                //    plantCost = plant.Cost,
                //    mainForm = this,
                //    Width = AssetInfo.PlantCardSize.Width,
                //    Location = new Point(i * AssetInfo.PlantCardSize.Width, 0)
                //};

                var plantCard = new PlantCardPictureBox()
                {
                    PlantIndex = plant.Index,
                    PlantCost = plant.Cost,
                    CooldownTime = plant.CooldownTime,
                    Dock = DockStyle.Left,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = AssetInfo.PlantCardSize.Width,
                    ImageLocation = Application.StartupPath + $"/Assets/Cards/{plant.Name}Card.png"
                };

                panelPlantList.Controls.Add(plantCard);
                plantCard.InitializeComponents();
                plantCard.BringToFront();
            }
        }

        public void LoadSunCount()
        {
            lblSunCount.Text = GameInfo.SunCount.ToString();
        }

        private void LoadGameArea()
        {
            var bitmapGameArea = new Bitmap(picBoxGameArea.ClientRectangle.Size.Width, picBoxGameArea.ClientRectangle.Size.Height);
            var canvas = Graphics.FromImage(bitmapGameArea);

            for (int i = 0; i < GameInfo.RowCount; i++)
            {
                var lawnMower = new LawnMower(picBoxGameArea, this);
                lawnMower.PlaceToMap(GameInfo.GameAreaLeftPadding, ((i + 1) * AssetInfo.PlantTileSize.Height) + GameInfo.GameAreaTopPadding - AssetInfo.LawnMowerSize.Height);

                for (int j = 0; j < GameInfo.ColumnCount; j++)
                {
                    canvas.DrawImage(Image.FromFile(Application.StartupPath + "/Assets/General/Grass.png"), (j * AssetInfo.PlantTileSize.Width) + GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width, (i * AssetInfo.PlantTileSize.Height) + GameInfo.GameAreaTopPadding, AssetInfo.PlantTileSize.Width, AssetInfo.PlantTileSize.Height);
                    //canvas.FillRectangle(new SolidBrush(colorTiles[i % 2][j % 2]), (j * AssetInfo.PlantTileSize.Width) + GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width, (i * AssetInfo.PlantTileSize.Height) + GameInfo.GameAreaTopPadding, AssetInfo.PlantTileSize.Width, AssetInfo.PlantTileSize.Height);
                }
            }

            picBoxGameArea.Image = bitmapGameArea;
        }

        private void timerRandomSun_Tick(object sender, EventArgs e)
        {
            int randomSunX = random.Next(GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width, (GameInfo.ColumnCount * AssetInfo.SunSize.Width) + GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width - AssetInfo.SunSize.Width);
            int randomSunY = random.Next(-40, -30);

            var sun = new Sun(picBoxGameArea, this);
            var picBoxSun = sun.GetSunPictureBox(randomSunX, randomSunY, random.Next(((GameInfo.RowCount - 1) * AssetInfo.PlantTileSize.Height) + GameInfo.GameAreaTopPadding - AssetInfo.SunSize.Height, (GameInfo.RowCount * AssetInfo.PlantTileSize.Height) + GameInfo.GameAreaTopPadding - AssetInfo.SunSize.Height));

            picBoxGameArea.Controls.Add(picBoxSun);

            picBoxSun.BringToFront();
            picBoxSun.StartDropping();
        }

        private void picBoxGameArea_MouseClick(object sender, MouseEventArgs e)
        {
            GameInfo.CurrentMouseLocation = e.Location;

            PicBoxGameAreaClick(GameInfo.CurrentMouseLocation.X, GameInfo.CurrentMouseLocation.Y);
        }

        private void timerRandomZombie_Tick(object sender, EventArgs e)
        {
            var randomRow = random.Next(0, GameInfo.RowCount);

            var discoZombie = new DiscoZombie(picBoxGameArea, this)
            {
                Name = "DiscoZombie"
            };
            discoZombie.Spawn(picBoxGameArea.Width, GameInfo.GameAreaTopPadding + (randomRow * AssetInfo.PlantTileSize.Height));

            GameInfo.ZombieList.Add(discoZombie);
        }

        private void picBoxGameArea_MouseMove(object sender, MouseEventArgs e)
        {
            GameInfo.CurrentMouseLocation = e.Location;

            PicBoxGameAreaMouseMove(GameInfo.CurrentMouseLocation.X, GameInfo.CurrentMouseLocation.Y);
        }

        public void PicBoxGameAreaClick(int x, int y)
        {
            if (x >= GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width && x <= GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width + (GameInfo.ColumnCount * AssetInfo.PlantTileSize.Width))
            {
                if (y >= GameInfo.GameAreaTopPadding && y <= GameInfo.GameAreaTopPadding + (GameInfo.RowCount * AssetInfo.PlantTileSize.Height))
                {
                    if (SelectedPlant.Index != -1)
                    {
                        if (GameInfo.SunCount - plantList[SelectedPlant.Index].Cost < 0)
                        {
                            SelectedPlant.PlantCardPictureBox.TriggerInsufficientSunAnimation();
                            return;
                        }

                        var clickedRowNo = (y - GameInfo.GameAreaTopPadding) / AssetInfo.PlantTileSize.Height;
                        var clickedColNo = (x - GameInfo.GameAreaLeftPadding - AssetInfo.LawnMowerSize.Width) / AssetInfo.PlantTileSize.Width;

                        var selectedPlant = plantList[SelectedPlant.Index];
                        selectedPlant.PlantToGround(Convert.ToInt32((AssetInfo.PlantTileSize.Width * (clickedColNo + 0.5f)) + GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width - (AssetInfo.PlantedPlantSize.Width * 0.5f)), Convert.ToInt32((AssetInfo.PlantTileSize.Height * (clickedRowNo + 0.5f)) + GameInfo.GameAreaTopPadding - (AssetInfo.PlantedPlantSize.Height * 0.5f)));

                        SelectedPlant.PlantCardPictureBox.StartCooldown();
                        GameInfo.SunCount -= plantList[SelectedPlant.Index].Cost;
                        LoadSunCount();

                        SelectedPlant.Index = -1;
                        SelectedPlant.PlantCardPictureBox = null;
                    }
                }
            }
        }

        public void PicBoxGameAreaMouseMove(int x, int y)
        {
            if (x >= GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width && x <= GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width + (GameInfo.ColumnCount * AssetInfo.PlantTileSize.Width))
            {
                if (y >= GameInfo.GameAreaTopPadding && y <= GameInfo.GameAreaTopPadding + (GameInfo.RowCount * AssetInfo.PlantTileSize.Height))
                {
                    if (SelectedPlant.Index != -1)
                    {
                        var hoveredRowNo = (y - GameInfo.GameAreaTopPadding) / AssetInfo.PlantTileSize.Height;
                        var hoveredColNo = (x - GameInfo.GameAreaLeftPadding - AssetInfo.LawnMowerSize.Width) / AssetInfo.PlantTileSize.Width;

                        plantList[SelectedPlant.Index].SetTempPlant(Convert.ToInt32((AssetInfo.PlantTileSize.Width * (hoveredColNo + 0.5f)) + GameInfo.GameAreaLeftPadding + AssetInfo.LawnMowerSize.Width - (AssetInfo.PlantedPlantSize.Width * 0.5f)), Convert.ToInt32((AssetInfo.PlantTileSize.Height * (hoveredRowNo + 0.5f)) + GameInfo.GameAreaTopPadding - (AssetInfo.PlantedPlantSize.Height * 0.5f)));
                    }
                }
            }
        }
    }
}
