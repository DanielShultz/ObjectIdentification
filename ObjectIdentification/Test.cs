using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectIdentification.Properties;

namespace ObjectIdentification
{
    public partial class Test : Form
    {
        RoadSign Crossroads_with_priority = new RoadSign(Resources.Crossroads_with_priority, Resources.Crossroads_with_priority1, "Пересечение со второстепенной дорогой");
        RoadSign Curve_to_the_left = new RoadSign(Resources.Curve_to_the_left, Resources.Curve_to_the_left1, "Опасный поворот на лево");
        RoadSign Curve_to_the_right = new RoadSign(Resources.Curve_to_the_right, Resources.Curve_to_the_right1, "Опасный поворот на право");
        RoadSign No_entry_for_tractors = new RoadSign(Resources.No_entry_for_tractors, Resources.No_entry_for_tractors1, "Движение тракторов запрещено");
        RoadSign No_entry_for_trailers = new RoadSign(Resources.No_entry_for_trailers, Resources.No_entry_for_trailers1, "Движение с прицепом запрещено");
        RoadSign Road_narrow_on_both_sides = new RoadSign(Resources.Road_narrow_on_both_sides, Resources.Road_narrow_on_both_sides1, "Сужение дороги с обеих сторон");
        RoadSign Road_narrow_on_left_side = new RoadSign(Resources.Road_narrow_on_left_side, Resources.Road_narrow_on_left_side1, "Сужение дороги с левой стороны");
        RoadSign Road_narrow_on_right_side = new RoadSign(Resources.Road_narrow_on_right_side, Resources.Road_narrow_on_right_side1, "Сужение дороги с правой стороны");
        RoadSign Side_road_with_priority__from_the_left = new RoadSign(Resources.Side_road_with_priority__from_the_left, Resources.Side_road_with_priority__from_the_left1, "Примыкание второстепенной дороги с левой стороны");
        RoadSign Side_road_with_priority__from_the_right = new RoadSign(Resources.Side_road_with_priority__from_the_right, Resources.Side_road_with_priority__from_the_right1, "Примыкание второстепенной дороги с правой стороны");
        RoadSign Straight_ahead_or_left_turn_permitted = new RoadSign(Resources.Straight_ahead_or_left_turn_permitted, Resources.Straight_ahead_or_left_turn_permitted1, "Движение прямо или налево");
        RoadSign Straight_ahead_or_right_turn_permitted = new RoadSign(Resources.Straight_ahead_or_right_turn_permitted, Resources.Straight_ahead_or_right_turn_permitted1, "Движение прямо или направо");
        RoadSign Swing_bridge = new RoadSign(Resources.Swing_bridge, Resources.Swing_bridge1, "Разводной мост");
        RoadSign Uneven_road = new RoadSign(Resources.Uneven_road, Resources.Uneven_road1, "Неровная дорога");
        RoadSign Other_danger = new RoadSign(Resources.Other_danger, Resources.Other_danger1, "Прочие опасности");

        QuestionRoadSign[] test = new QuestionRoadSign[6];

        int n = 0;
        bool day = true;
        Random rnd = new Random();
        int random = 0;
        string[] names = { };
        bool[] mistakes = new bool[6];
        int answers = 0;

        public void Start(bool started)
        {
            ok.Visible = started;
            comboBox1.Visible = started;
            comboBox2.Visible = started;
            startDay.Visible = !started;
            startNight.Visible = !started;
            panel.Visible = started;
            if (started)
            {
                test[0] = new QuestionRoadSign(Road_narrow_on_both_sides, Road_narrow_on_left_side, Road_narrow_on_right_side);
                test[1] = new QuestionRoadSign(Crossroads_with_priority, Side_road_with_priority__from_the_left, Side_road_with_priority__from_the_right);
                test[2] = new QuestionRoadSign(Uneven_road, Swing_bridge);
                test[3] = new QuestionRoadSign(Other_danger, Curve_to_the_left, Curve_to_the_right);
                test[4] = new QuestionRoadSign(No_entry_for_tractors, No_entry_for_trailers);
                test[5] = new QuestionRoadSign(Straight_ahead_or_right_turn_permitted, Straight_ahead_or_left_turn_permitted);
                for (int i = 0; i < 6; i++)
                {
                    names = names.Union(test[i].Names()).ToArray();
                }
                n = 0;
                answers = 0;
            }
        }

        public Test()
        {
            InitializeComponent();
            pictureBox1.Image = Resources.Other_danger;
            pictureBox2.Image = Resources.Other_danger1;
            Start(false);
            for (int i = 0; i < 6; i++)
            {
                mistakes[i] = true;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                if (n<5)
                {
                    if (comboBox1.SelectedItem.ToString() == test[n].First().name && comboBox2.SelectedItem.ToString() == test[n].Second().name)
                    {
                        mistakes[n] = false;
                        panel.BackColor = Color.Green;
                        answers = 0;
                        foreach (var item in mistakes)
                        {
                            if (!item)
                            {
                                answers++;
                            }
                        }
                        log.Text = "Правильных ответов: " + answers + "/6";
                    }
                    else
                    {
                        mistakes[n] = true;
                        panel.BackColor = Color.Red;
                    }
                    n++;
                    if (day)
                    {
                        pictureBox1.Image = test[n].First().day;
                        pictureBox2.Image = test[n].Second().day;
                    }
                    else
                    {
                        pictureBox1.Image = test[n].First().night;
                        pictureBox2.Image = test[n].Second().night;
                    }
                }
                else
                {
                    Start(false);
                    BackColor = Color.White;
                    log.ForeColor = Color.Black;
                    pictureBox1.Image = Resources.Other_danger;
                    pictureBox2.Image = Resources.Other_danger1;
                }
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
        }

        private void startDay_Click(object sender, EventArgs e)
        {
            day = true;
            Start(true);
            log.Visible = true;
            comboBox1.Items.AddRange(names);
            comboBox2.Items.AddRange(names);
            pictureBox1.Image = test[n].First().day;
            pictureBox2.Image = test[n].Second().day;
        }

        private void startNight_Click(object sender, EventArgs e)
        {
            day = false;
            Start(true);
            log.Visible = true;
            log.Text = "Правильных ответов: " + answers + "/6";
            BackColor = Color.Black;
            log.ForeColor = Color.White;
            comboBox1.Items.AddRange(names);
            comboBox2.Items.AddRange(names);
            pictureBox1.Image = test[n].First().night;
            pictureBox2.Image = test[n].Second().night;
        }
    }
}
