using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace игра
{
    public partial class Form2 : Form
    {

        PictureBox[] pictureBoxes;
        RadioButton[] radioButton;
        ToolTip t = new ToolTip();
        public Form2()
        {
            InitializeComponent();

            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox15, pictureBox17 };
            radioButton = new RadioButton[] { radioButton4, radioButton5, radioButton6, radioButton7, radioButton8 };

        }

        string[] attack = new string[] {/*Первая стадия*/"Зловещий взгляд","Обезглавливание","Колесо ужаса","3 удара косой","Удар косой",
               /* ,Вторая стадия*/"Шепот безумных","Взгляд страху в глаза", "Загадочный туман" };
        string[,] attackopisanie = new string[3, 12] {{ 
            /*Зловещий взгляд*/"Глаза загораются зловеще зеленым светом и образец XY пристальным взором смотрит на игрока",
            /*Обезглавнивание*/"образец XY исчезает, оставляя зеленоватую дымку и слышится взмах косы, разрезающий воздух",
            /*Колесо ужаса*/"образец XY зависает в воздухе, поднимая косу на головой, раскручивает ее и запусает в игрока",
            /*3 удара косой*/ "Замахивается косой на левую сторону и резким скачком приближается", 
            /*3 удара косой*/"Резким движением прокручивает косу и начинает ее вести снизу вверх",
            /*3 удара косой*/"Резким движением прокручивает косу и быстро пикирует косой в направление игрока",            
            /*Удар косой(1)*/"Заносит косу за спину с левой стороны и с быстрым движением вперед атакует",
            /*Удар косой(2)*/"Заносит косу над головой и с быстрым движением вперед пикирует ей на игрока ",
            /*Удар косой(3)*/"Опускает косу и резко атакует",
            /*Удар косой(4)*/"Заносит косу за спину с правой стороны, перекручивает и с быстрым движением вперед атакует",
            /*Удар косой(5)*/"Он берет косу в левую руку, коса начинает светится фиолетовой энергией и ты видишь, " +
                "как множество взмахов летит в игрока",
            /*Шепот безумных*/"Образец исчезает, и комната заполняется ярким светом, пол под рыцарем проваливается, и он падает в бездну." +
                "Слышится множество голосов, но один из них рыцарю знаком.",
               /* "1Загадочный туман",
                "2Загадочный туман",*/},
            { /*Зловещий взгляд*/"игрока ан тиртомс морозв мыньлатсирп YX цезарбо и мотевс мынелез ещеволз ястюарогаз азалГ",
            /*Обезглавнивание*/"воздух йищюазерзар ,ысок хамзв ястишылс и укмыд юутавонелез яялватсо ,теазечси YX цезарбо",
            /*Колесо ужаса*/"игрока в теасупаз и ее теавичурксар ,йоволог ан усок яаминдоп ,ехудзов в теасиваз YX цезарбо",
            /*3 удара косой*/ "приближается мокчакс микзер и уноротс юувел ан йосок ястеавихамаЗ", 
            /*3 удара косой*/"вверх узинс итсев ее теаничан и усок теавичуркорп меинеживд микзеР",
            /*3 удара косой*/"игрока еинелварпан в йосок теурикип ортсыб и усок теавичуркорп меинеживд микзеР",            
            /*Удар косой(1)*/"атакует дерепв меинеживд мыртсыб с и ыноротс йовел с унипс аз усок тисонаЗ",
            /*Удар косой(2)*/"игрока ан йе теурикип дерепв меинеживд мыртсыб с и йоволог дан усок тисонаЗ",
            /*Удар косой(3)*/"атакует окзер и усок теаксупО",
            /*Удар косой(4)*/"атакует дерепв меинеживд мыртсыб с и теавичуркереп ,ыноротс йоварп с унипс аз усок тисонаЗ",
            /*Удар косой(5)*/"игрока в тител вохамзв овтсежонм как ,ьшидив ыт и йеигренэ йовотелоиф яститевс теаничан асок ," +
                "укур юувел в усок тереб нО",
            ".моканз юрацыр хин зи нидо он ,восолог овтсежонм ястишылС" +
                ".ундзеб в теадап но и ,ястеавилаворп мерацыр доп лоп ,мотевс микря ястеянлопаз атанмок и ,теазечси цезарбО.",
               },{
        /*Зловещий взгляд*/"лаа аораются зовее зеенм етом и оазец XY пистаьным взоо морит на игоа",
            /*Обезглавнивание*/"оазец XY исеает, отавяя зееноатую дыу и лыится вах кы, рзреающий воух",
            /*Колесо ужаса*/"оазец XY аисает в воухе, одимая ку на олово, раручивает ее и апуает в игоа",
            /*3 удара косой*/ "Заахиваеся кой на еую соону и реим саком прилиается",            
            /*3 удара косой*/"езим диженем покручивет ко и нчинет ее веи изу ерх",
            /*3 удара косой*/"езим диженем покручивет ко и быро пииует кой в наравлене игоа",            
            /*Удар косой(1)*/"аосит оу за сиу с еой ороны и с бырым виением еред аакет",
            /*Удар косой(2)*/"аосит оу над гооой и с бытрм дижение еред пиируе ей на игоа ",
            /*Удар косой(3)*/"Оусает оу и рео ааует",
            /*Удар косой(4)*/"аосит оу за сиу с авой ороны, ереручивает и с бырым двинием еред аакет",
            /*Удар косой(5)*/"Он еет оу в леу уу, оа ачинае етится иолетово ергией и ты вииш, " +
                "как можеств взахв етт в игоа",
            "1Шепот безумных",} };
        string[] attackDodge = new string[] { 
            /*Зловещий взгляд(идеал)*/"Успокоиться и собраться с мыслями",
            /*Зловещий взгляд(средне)*/"Не Смотреть в глаза",
            /*Обезглавнивание*/ "Развернуться и блокировать", "Кувырок вперед", 
            /*Колесо ужаса*/"Бросок бомбы","Кувырок вперед",
            /*3 удара косой(1)*/"Отскок", "Кувырок влево","Блокировать атаку в левую часть тела",
            /*3 удара косой(2)*/"Блокировать атаку в ноги","Кувырок влево",
            /*3 удара косой(3)*/ "Блокировать атаку в голову", "Кувырок влево",           
            /*Удар косой(1)*/"Кувырок вправо","Блокировать атаку в левую часть тела",
            /*Удар косой(2)*/"Кувырок вправо","Блокировать атаку в голову","Кувырок влево",
            /*Удар косой(3)*/"Прыжок","Блокировать атаку в ноги",
            /*Удар косой(4)*/"Кувырок влево","Блокировать атаку в правую часть тела",
            /*Удар косой(5)*/"Кувырок вправо",
            /*Шепот безумных*/"Стремление выжить","5","Голдор","Стремление выжить","Стремление выжить",
            /*"Шепот безумных"*/""
            /* "Загадочный туман", "Шепот безумных"*/};
        string[] attackplus = new string[] { 
            /*Зловещий взгляд*/"Вы упали на колени, ваши мысли путаются, вы чуствуете,что истекаете кровью, но крови не видно",
            /*Зловещий взгляд(вариант Не Смотреть в глаза)*/
                "Вы почуствовали странное чуство забывчивости, вы немного чуствуете дискомфорт в глазах",
            /*Обезглавнивание*/"Вы погибли",
            /*Колесо ужаса(не смертельное)*/ "Вас серьезно ранили",
            /*Колесо ужаса(смертельное)*/ "Вы погибли",
            /*Комбо и просто удар(не смертельное)*/"Вас ранили",
            /*Комбо и просто удар(смертельное)*/"Вы погибли",
            /* "", "","Загадочный туман", "Шепот безумных",
                            "Загадочный туман", "Шепот безумных"*/};
        string[] attackminus = new string[] { 
            /*Зловещий взгляд*/"Вы успоколи свой разум и не поддались страху",
            /*Обезглавнивание(блокирование)*/"Потратив большое количество сил, вам удалось заблокировать удар",
            /*Обезглавнивание(уворот)*/"В последний момент кувырком вперед вы спасли свою голову от отделения от тела",
            /*Колесо ужаса(атака)*/"Его атака сбита, он упал и тяжело встает",
            /*Колесо ужаса(уворот)*/"Быстро рванув вперед и ,сделав кувырок, раздался взрыв отбросивший вас вперед, после чего вы быстро поднялись на ноги",
            /*Комбо и просто удар(уворот)*/"Его коса пронислась над вашим телом, не срезав не единого волосика",
            /*Комбо и просто удар(блокирование)*/"Его коса с громким звуком отскочила от вашего щита",
            /*Комбо и просто удар(прыжок)*/"Его коса проносится под вашими ногами",
               /* "", "","Загадочный туман", "Шепот безумных" */};
        int s=1500;
        string[] vopros = new string[]
        { /*стремление выжить*/"Ты забрал щит, лишил меня самого дорогого, ты хоть помнишь, что значит этот щит для меня?",
        /*5*/"Обо мне ты немного помнишь, но не забыл ли остальных, вспомнишь ли сколько нас было все подсказки у тебя есть?",
        /*Голдор*/"Нас ты не забыл, но помнишь ли ты королевство, служба в котором связала нас вместе?",
      };
        string[] otvet = new string[]
        { /*стремление выжить*/"Cтремление выжить",
        /*5*/"5",
        /*Голдор*/"Голдор",
      };
        bool magia = false;
        int timd = 0;
        int voprosnumber=0;
        string[] attackcount = new string[400];
        string directory = Environment.CurrentDirectory.ToString();
        int i;
        int k = 1;
        int podgotovka=0;
        double  madness = 0;
        int countmedal = 0;
        int color = 0;
        int bomb = 3, count=0;
        Random rand = new Random();
        int dodge = 0;
        
        int[][] attackbegin = new int[3][];
        string item="", item2="";
        int d, hp = 3, hpboss = 3;
        int combo=0;
        int yui = 0;
        int antistres = 3, herbal_potion=3;
        int[] countx = new int[5] {0,0,0,0,0};
        string[] dodgeop = new string[]{ "Образец легко уворачивается от вашей атаки", "Образец легко парирует вашу атаку" };
        string[] dodgneod = new string[] { "не успев увернуться", "не успев спарировать" };
        string[] str = new string[] { "Образец XY:", "Защита противник:", "Атака противник:" };
        string[] struser = new string[] { "Рыцарь:", "Защита персонаж:", "Атака персонаж:" };
        bool fhazaone = false;
        private void attackfunction()
        {
            if (hpboss == 1)
                timd++;
            if (timd == 10)
            {
                timer1.Stop();
                this.Hide();
                Form4 f4 = new Form4();
                f4.ShowDialog();
                Application.Exit();
            }
            if (countmedal > 0)
                countmedal--;
            count++;           
            dodge = rand.Next(1, 10) + podgotovka;
            int tump = rand.Next(dodgeop.Length);
            if (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true
                || radioButton7.Checked == true || radioButton8.Checked == true)
            {
                if (radioButton4.Checked == true)//выпад мечом
                {
                    richTextBox1.Text = richTextBox1.Text + "Атака персонаж: " + "Выпад с мечом"+ Environment.NewLine;
                    podgotovka = 0;                  
                    if (count > 1 && (attackcount[count - 1] != radioButton4.Text && attackcount[count - 2] != radioButton4.Text) && countx[0] > 0)
                    {
                        countx[0] = 0;                        
                    }
                    countx[0] = countx[0] + 1;
                    if (fhazaone == true)
                    {
                        fhazaone = false;
                        hpboss--;
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + "Успокоительное на вашем мече обожгло рану и Образец не смог регенировать" 
                            + Environment.NewLine;
                        for (int i = 6 - 1; i >= 1; i--)//Алгоритм Фишера – Йетса
                        {
                            int u = rand.Next(i + 1);
                            int temp = attackbegin[hpboss - 1][u];
                            attackbegin[hpboss - 1][u] = attackbegin[hpboss - 1][i];
                            attackbegin[hpboss - 1][i] = temp;
                        }
                            var MyImage = new Bitmap(directory + "\\неизвестность" + hpboss.ToString() + ".jpg");
                        pictureBox4.Image = (Image)MyImage;
                    }
                    else
                    if (countx[0] > 2 && (attackcount[count - 1] == radioButton4.Text && attackcount[count - 2] == radioButton4.Text))
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: "+dodgeop[tump] + Environment.NewLine;
                    }
                    else
                   if (countx[0] > 1)
                    {
                        if (dodge <= 7)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[tump] + Environment.NewLine;
                        }
                        else
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: "+ dodgneod[tump]+", получил рану, но вскоре отрегенирировался" 
                                + Environment.NewLine;
                        }
                    }
                    else
                    if (dodge <= 5)
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: "+dodgeop[tump] + Environment.NewLine;
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgneod[tump] + ", получил рану, но вскоре отрегенирировался"
                                + Environment.NewLine;
                    }
                    attackcount[count] = radioButton4.Text;
                }
                else
                if (radioButton5.Checked == true)//горизонтальный удар мечом
                {
                    richTextBox1.Text = richTextBox1.Text + "Атака персонаж: " + "Горизонтальный удар мечом" + Environment.NewLine;
                    podgotovka = 0;
                    if (count > 1 && (attackcount[count - 1] != radioButton5.Text && attackcount[count - 2] != radioButton5.Text) && countx[1] > 0)
                    {
                        countx[1] = 0;
                    }
                    countx[1] = countx[1] + 1;
                    if (fhazaone == true)
                    {
                        fhazaone = false;
                        hpboss--;
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + "Успокоительное на вашем мече обожгло рану и Образец не смог регенировать"
                            + Environment.NewLine;
                        for (int i = 6 - 1; i >= 1; i--)//Алгоритм Фишера – Йетса
                        {
                            int u = rand.Next(i + 1);
                            int temp = attackbegin[hpboss - 1][u];
                            attackbegin[hpboss - 1][u] = attackbegin[hpboss - 1][i];
                            attackbegin[hpboss - 1][i] = temp;
                        }
                            var MyImage = new Bitmap(directory + "\\неизвестность" + hpboss.ToString() + ".jpg");
                        pictureBox4.Image = (Image)MyImage;
                    }
                    else
                    if (countx[1] > 2 && (attackcount[count - 1] == radioButton5.Text && attackcount[count - 2] == radioButton5.Text))
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[tump] + Environment.NewLine;
                    }
                    else
                     if (countx[1] > 1)
                    {
                        if (dodge <= 7)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[tump] + Environment.NewLine;
                        }
                        else
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgneod[tump] + ", получил рану, но вскоре отрегенирировался"
                                + Environment.NewLine;
                        }
                    }
                    else
                    if (dodge <= 5)
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[tump] + Environment.NewLine;
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgneod[tump] + ", получил рану, но вскоре отрегенирировался"
                                + Environment.NewLine;
                    }
                    attackcount[count] = radioButton5.Text;
                }
                else
                if (radioButton6.Checked == true)//подготовка
                {
                    richTextBox1.Text = richTextBox1.Text + "Атака персонаж: " + "Подготовка" + Environment.NewLine;
                    if (attackcount[count - 1] != radioButton6.Text && countx[4] > 0)
                    {
                        countx[4] = 0;
                    }
                    countx[4] ++;
                    if (countx[4] > 1)
                    {
                        podgotovka = 4;
                        richTextBox1.Text = richTextBox1.Text +"Вы хорошо подготовились следующая атака будет точнее" + Environment.NewLine;
                    }
                    else
                    {
                        podgotovka = 2;
                        richTextBox1.Text = richTextBox1.Text + "Вы немного подготовились следующая атака будет точнее" + Environment.NewLine;
                    }
                    attackcount[count] = radioButton6.Text;
                }
                else
                    if (radioButton7.Checked == true)// бросок бомбы
                {
                    richTextBox1.Text = richTextBox1.Text + "Атака персонаж: " + "Бросок бомбы" + Environment.NewLine;
                    podgotovka = 0;
                    if (count > 1 && (attackcount[count - 1] != radioButton7.Text && attackcount[count - 2] != radioButton7.Text) && countx[2] > 0)
                    {
                        countx[2] = 0;
                    }
                    countx[2] = countx[2] + 1;
                    if (countx[2] > 2 && (attackcount[count - 1] == radioButton7.Text && attackcount[count - 2] == radioButton7.Text))
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[0] + Environment.NewLine;
                    }
                    else
                     if (countx[2] > 1)
                    {
                        if (dodge <= 3)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[0] + Environment.NewLine;
                        }
                        else
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgneod[tump] + ", получил серьезную рану, но вскоре отрегенирировался"
                               + Environment.NewLine;
                        }
                    }
                    else
                    if (dodge <= 3)
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[0] + Environment.NewLine;
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgneod[tump] + ", получил серьезную рану, но вскоре отрегенирировался"
                               + Environment.NewLine;
                    }
                    bomb--;
                    t.SetToolTip(pictureBox6, "Бомба\n" + Properties.Resources.Бомба + "\nКоличество: " + bomb.ToString());
                    attackcount[count] = radioButton7.Text;
                }
                else
                    if (radioButton8.Checked == true) //удар щитом
                {
                    richTextBox1.Text = richTextBox1.Text + "Атака персонаж: " + "Удар щитом" + Environment.NewLine;
                    if (count > 1 && (attackcount[count - 1] != radioButton8.Text && attackcount[count - 2] != radioButton8.Text) && countx[3] > 0)
                    {
                        countx[3] = 0;
                    }
                    countx[3] = countx[3] + 1;
                    if (countx[3] > 3 && (attackcount[count - 1] == radioButton8.Text && attackcount[count - 2] == radioButton8.Text
                        && attackcount[count - 3] == radioButton8.Text))
                    {
                        richTextBox1.Text = richTextBox1.Text +"Защита противник: " + dodgeop[tump] + Environment.NewLine;
                    }
                    else
                     if (countx[3] > 2 && (attackcount[count - 1] == radioButton8.Text && attackcount[count - 2] == radioButton8.Text))
                    {
                        if (dodge <= 6)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[tump] + Environment.NewLine;
                        }
                        else
                        {
                            d = rand.Next(1, 10);
                            if (d == 1)
                                richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgneod[tump] + ",получил оглушение и вы можете атаковать повторно"
                                + Environment.NewLine;
                            else
                                richTextBox1.Text = richTextBox1.Text + "Защита противник: "+dodgneod[tump] + ",пропустил сильный удар, но  не понес никаких повреждений"
                                + Environment.NewLine;
                        }
                    }
                    else
                    if (countx[3] > 1)
                    {
                        if (dodge <= 5)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[tump] + Environment.NewLine;
                        }
                        else
                        {
                            d = rand.Next(1, 10)+podgotovka / 2;
                            if (d == 1)
                                richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgneod[tump] + ",получил оглушение и вы можете атаковать повторно"
                                + Environment.NewLine;
                            else
                                richTextBox1.Text = richTextBox1.Text + "Защита противник: "+dodgneod[tump] + ",пропустил сильный удар, но  не понес никаких повреждений"
                                + Environment.NewLine;
                        }
                    }
                    else
                    if (dodge <= 3)
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита противник: " + dodgeop[tump] + Environment.NewLine;
                    }
                    else
                    {
                        d = rand.Next(1, 10)+podgotovka/2;
                        if (d <= 3)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита противник: "+ dodgneod[tump]+",получил оглушение и вы можете атаковать повторно" 
                                + Environment.NewLine;
                        }
                        else
                        {
                            richTextBox1.Text = richTextBox1.Text  + "Защита противник: "+dodgneod[tump] + ",пропустил сильный удар, но  не понес никаких повреждений"  
                                + Environment.NewLine;
                        }
                    }
                    attackcount[count] = radioButton8.Text;
                    podgotovka = 0;
                }
            }           
            if (count == 6 && hpboss==3)
            {
                richTextBox1.Text = richTextBox1.Text + "Атака противник: " + "Образец пронзает себя своей косой, взрывая себя и моментально " +
                    "регенерирует себя, кроме дыры в теле" + Environment.NewLine;
                hpboss--;
                count = 1;
                var MyImage = new Bitmap(directory + "\\неизвестность" + hpboss.ToString() + ".jpg");
                pictureBox4.Image = (Image)MyImage;
            }
            if (count == 6 && hpboss == 1)
            {
                count = 1;
                for (int i = 5 - 1; i >= 1; i--)//Алгоритм Фишера – Йетса
                {
                    int u = rand.Next(i + 1);
                    int temp = attackbegin[hpboss - 1][u];
                    attackbegin[hpboss - 1][u] = attackbegin[hpboss - 1][i];
                    attackbegin[hpboss - 1][i] = temp;
                }

            }

            if (attackbegin[hpboss - 1][count - 1] == 2)
                    yui = 0;
                if (count > 1)
                {
                    if (attackbegin[hpboss - 1][count - 2] != 3)
                    {
                        richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                    }
                }
                else
                    richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                if (attackbegin[hpboss - 1][count - 1] == 4)
                {
                    d = rand.Next(1, 5);
                    richTextBox1.Text = richTextBox1.Text + "Атака противник: " + attackopisanie[int.Parse(madness.ToString()), 5 + d]
                        + Environment.NewLine;
                }
            else
                if(attackbegin[hpboss - 1][count - 1] == 5) 
            { 
            
                richTextBox1.Text = richTextBox1.Text + "Атака противник: " + attackopisanie[int.Parse(madness.ToString()), 11] + Environment.NewLine;
                richTextBox1.Text = richTextBox1.Text + "Голос: " + vopros[voprosnumber] + Environment.NewLine;
            }
                else
                richTextBox1.Text = richTextBox1.Text + "Атака противник: " +
                            attackopisanie[int.Parse(madness.ToString()), attackbegin[hpboss - 1][count - 1]] + Environment.NewLine;

            radioButton4.ForeColor = Color.Black;
            radioButton5.ForeColor = Color.Black; 
            radioButton6.ForeColor = Color.Black;
            radioButton7.ForeColor = Color.Black;
            radioButton8.ForeColor = Color.Black;

            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;

            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            comboBox1.Items.Clear();
            if (attackbegin[hpboss - 1][count - 1] == 0)
                comboBox1.Items.AddRange(new object[]
                       {"Защитное действие",
                   "Защита"});
            else if (attackbegin[hpboss - 1][count - 1] == 2)
                comboBox1.Items.AddRange(new object[]
                   {"Уворот",
                   "Атака"});
            else if (attackbegin[hpboss - 1][count - 1] == 5)
            {
                comboBox1.Items.AddRange(new object[]
                   {"Защитное действие"});
                voprosnumber++;
                k = 5;
            }
            else
                comboBox1.Items.AddRange(new object[]
                   {"Уворот",
                   "Защита"});
        }
        private void protectionfunction()
        {
            int g = 0;
            if (attackbegin[hpboss - 1][count - 1] < 3 && attackbegin[hpboss - 1][count - 1] > 0)//атаки обезглавливание и колесо ужаса
            {               
                for (int i = 0; i < radioButton.Length; i++)
                {
                    if ((attackDodge[attackbegin[hpboss - 1][count - 1] * 2] == radioButton[i].Text || attackDodge[attackbegin[hpboss - 1][count - 1] * 2 + 1] == radioButton[i].Text)
                            && radioButton[i].Checked == true)
                    {
                        if (comboBox1.Text == "Уворот")
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[attackbegin[hpboss - 1][(count - 1)] * 2] + Environment.NewLine;
                            g = 1;
                            yui = 1;
                            break;
                        }
                        else
                            if (comboBox1.Text == "Защита")
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[1] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                        else
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[3] + Environment.NewLine;
                            bomb--;
                            t.SetToolTip(pictureBox6, "Бомба\n" + Properties.Resources.Бомба + "\nКоличество: " + bomb.ToString());
                            g = 1;
                            yui = 1;
                            break;
                        }


                    }
                }


                if (attackbegin[hpboss - 1][count - 1] == 1 && g != 1)
                {
                    hp = 0;
                    var MyImage = new Bitmap(directory + "\\HP" + hp.ToString() + ".jpg");
                    pictureBox3.Image = (Image)MyImage;
                    timer1.Stop();
                    MessageBox.Show(attackplus[2]);
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                    Application.Exit();
                }
                if (attackbegin[hpboss - 1][count - 1] == 2 && g != 1)
                {
                    hp = hp - 2;
                    yui = 1;
                    if (hp < 0)
                        hp = 0;
                    var MyImage = new Bitmap(directory + "\\HP" + hp.ToString() + ".jpg");
                    pictureBox3.Image = (Image)MyImage;
                    if (hp == 0)
                    {
                        timer1.Stop();
                        MessageBox.Show(attackplus[4]);
                        this.Hide();
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                        Application.Exit();
                    }
                    else
                        richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackplus[3] + Environment.NewLine;

                }

            }
            else
            if (attackbegin[hpboss - 1][count - 1] == 0)
            {
                for (int i = 0; i < radioButton.Length; i++)
                {
                    if (attackDodge[0] == radioButton[i].Text && radioButton[i].Checked == true)
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[0] + Environment.NewLine;
                        g = 1;
                        break;
                    }
                    else
                        if (attackDodge[1] == radioButton[i].Text && radioButton[i].Checked == true)
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackplus[1] + Environment.NewLine;
                        madness = madness + 0.5;
                        g = 1;
                        break;
                    }
                }
                if (attackbegin[hpboss - 1][count - 1] == 0 && g != 1)
                {
                    madness = madness + 1;
                    richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackplus[0] + Environment.NewLine;
                }

            }
            else
            if (attackbegin[hpboss - 1][count - 1] == 4)
            {
                for (int i = 0; i < radioButton.Length; i++)
                {
                    if (5 + d == 6)
                    {
                        if (attackDodge[13] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[5] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                        else
                        if (attackDodge[14] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[6] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                    }
                    else
                    if (5 + d == 7)
                    {
                        if (attackDodge[15] == radioButton[i].Text && radioButton[i].Checked == true ||
                            attackDodge[17] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[5] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                        else
                            if (attackDodge[16] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[6] + Environment.NewLine;
                            g = 1;
                            break;
                        }

                    }
                    else
                    if (5 + d == 8)
                    {
                        if (attackDodge[18] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[7] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                        else
                        if (attackDodge[19] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[6] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                    }
                    else
                    if (5 + d == 9)
                    {
                        if (attackDodge[20] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[5] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                        else
                        if (attackDodge[21] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[6] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                    }
                    else
                    {
                        if (attackDodge[22] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[5] + Environment.NewLine;
                            g = 1;
                            break;
                        }
                    }
                }
                if (attackbegin[hpboss - 1][count - 1] == 4 && g != 1)
                {
                    hp = hp - 1;
                    if (hp < 0)
                        hp = 0;
                    var MyImage = new Bitmap(directory + "\\HP" + hp.ToString() + ".jpg");
                    pictureBox3.Image = (Image)MyImage;
                    if (hp == 0)
                    {
                        timer1.Stop();
                        MessageBox.Show(attackplus[6]);
                        this.Hide();
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                        Application.Exit();
                    }
                    else
                        richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackplus[5] + Environment.NewLine;
                }
            }
            else
            if (attackbegin[hpboss - 1][count - 1] == 3)
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < radioButton.Length; i++)
                {
                    if (combo == 0)
                    {
                        if (attackDodge[6] == radioButton[i].Text && radioButton[i].Checked == true ||
                            attackDodge[7] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[5] + Environment.NewLine;
                            combo++;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " + 
                                attackopisanie[int.Parse(madness.ToString()), 4] + Environment.NewLine;
                            g = 1;
                            comboBox1.Items.AddRange(new object[]
                   {"Защита",
                   "Уворот"});
                            break;
                        }
                        else
                            if (attackDodge[8] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[5] + Environment.NewLine;
                            combo++;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " + 
                                attackopisanie[int.Parse(madness.ToString()), 4] + Environment.NewLine;
                            g = 1;
                            comboBox1.Items.AddRange(new object[]
                   {"Защита",
                   "Уворот"});
                            break;
                        }
                    }
                    else
                        if (combo == 1)
                    {
                        if (attackDodge[10] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[5] + Environment.NewLine;
                            combo++;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " + 
                                attackopisanie[int.Parse(madness.ToString()), 5] + Environment.NewLine;
                            g = 1;
                            comboBox1.Items.AddRange(new object[]
                   {"Защита",
                   "Уворот"});
                            break;
                        }
                        else
                        if (attackDodge[9] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[6] + Environment.NewLine;
                            combo++;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " + 
                                attackopisanie[int.Parse(madness.ToString()), 5] + Environment.NewLine;
                            g = 1;
                            comboBox1.Items.AddRange(new object[]
                   {"Защита",
                   "Уворот"});
                            break;
                        }
                    }
                    if (combo == 2)
                    {
                        if (attackDodge[12] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[5] + Environment.NewLine;
                            combo=0;
                            s = 1500;
                            g = 1;
                            comboBox1.Items.AddRange(new object[]
                   {"Защита",
                   "Уворот"});
                            break;
                        }
                        else
                        if (attackDodge[11] == radioButton[i].Text && radioButton[i].Checked == true)
                        {
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackminus[6] + Environment.NewLine;
                            combo = 0;
                            s = 1500;
                            g = 1;
                            comboBox1.Items.AddRange(new object[]
                   {"Защита",
                   "Уворот"});
                            break;
                        }
                    }
                }
                if (g != 1)
                {
                    hp = hp - 1;
                    if (hp < 0)
                        hp = 0;
                    var MyImage = new Bitmap(directory + "\\HP" + hp.ToString() + ".jpg");
                    pictureBox3.Image = (Image)MyImage;
                    if (hp == 0)
                    {
                        timer1.Stop();
                        MessageBox.Show(attackplus[6]);
                        this.Hide();
                        Form3 f3 = new Form3();
                       f3.ShowDialog();
                        Application.Exit();     
                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackplus[5] + Environment.NewLine;
                        if (combo == 0)
                        {
                            combo++;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " + 
                                attackopisanie[int.Parse(madness.ToString()), 4] + Environment.NewLine;
                            comboBox1.Items.AddRange(new object[]
                  {"Защита",
                   "Уворот"});
                        }
                        else
                            if (combo==1)
                        {
                            combo++;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " + 
                                attackopisanie[int.Parse(madness.ToString()), 5] + Environment.NewLine;
                            comboBox1.Items.AddRange(new object[]
                  {"Защита",
                   "Уворот"});
                        }
                        else if (combo == 2)
                        {
                            s = 1500;
                            combo=0;
                        }
                    }
                }
            }else
                if (attackbegin[hpboss - 1][count - 1] == 5)
            {
                for (int i = 0; i < radioButton.Length; i++)
                {
                    if (otvet[voprosnumber-1] == radioButton[i].Text && radioButton[i].Checked == true)
                    {
                        richTextBox1.Text = richTextBox1.Text + "Рыцарь: " + otvet[voprosnumber-1] + Environment.NewLine;
                        richTextBox1.Text = richTextBox1.Text + "Голос: " + "так ты помнишь" + Environment.NewLine;
                        hpboss--;
                        for ( i = 5 - 1; i >= 1; i--)//Алгоритм Фишера – Йетса
                        {
                            int u = rand.Next(i + 1);
                            int temp = attackbegin[hpboss - 1][u];
                            attackbegin[hpboss - 1][u] = attackbegin[hpboss - 1][i];
                            attackbegin[hpboss - 1][i] = temp;
                        }
                        var MyImage = new Bitmap(directory + "\\неизвестность" + hpboss.ToString() + ".jpg");
                        pictureBox4.Image = (Image)MyImage;
                        g = 1;
                        k = 1;
                        break;
                    }
                }
                if (g != 1)
                {
                    k = 1;
                    hp = hp - voprosnumber;
                    richTextBox1.Text = richTextBox1.Text + "Рыцарь: " + otvet[voprosnumber-1] + Environment.NewLine;
                    if (hp < 0)
                        hp = 0;
                    var MyImage = new Bitmap(directory + "\\HP" + hp.ToString() + ".jpg");
                    pictureBox3.Image = (Image)MyImage;
                    if (hp == 0)
                    {
                        timer1.Stop();
                        MessageBox.Show(attackplus[6]);
                        this.Hide();
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                        Application.Exit();
                    }
                }
            }
            radioButton4.ForeColor = Color.Black;
            radioButton5.ForeColor = Color.Black;
            radioButton6.ForeColor = Color.Black;
            radioButton7.ForeColor = Color.Black;
            radioButton8.ForeColor = Color.Black;

            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;

            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            if (combo == 0)
            {               
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new object[]
                       {"Атака"});                
                richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
            }
        }       
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Атака")
            {
                s = 1500;
                if (count > 0)
                {
                    if (attackbegin[hpboss - 1][count - 1] == 2 && yui != 1)
                    {
                        protectionfunction();
                    }
                    else
                        attackfunction();
                }
                else
                    attackfunction();
            }
            else
            {
                if (comboBox1.Text == "Защита" || comboBox1.Text == "Уворот" || comboBox1.Text == "Защитное действие")
                {
                    if (attackbegin[hpboss - 1][count-1]!=3)
                    s = 1500;
                    protectionfunction();
                }
            }

        }
        private void Form2_Resize(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(groupBox1.Location.X+ groupBox1.Width, pictureBox2.Location.Y);
            richTextBox1.Location = new Point(pictureBox1.Location.X + pictureBox1.Width, richTextBox1.Location.Y);
            pictureBox2.Location = new Point(richTextBox1.Location.X + richTextBox1.Width, pictureBox2.Location.Y);
            pictureBox3.Location = new Point(pictureBox1.Width / 2 - pictureBox3.Width / 2 + pictureBox1.Location.X, pictureBox1.Location.Y - pictureBox3.Height);
             pictureBox4.Location = new Point(pictureBox2.Width / 2 - pictureBox4.Width / 2 + pictureBox2.Location.X, pictureBox2.Location.Y - pictureBox4.Height);                     
            button1.Location = new Point(button1.Location.X, pictureBox1.Location.Y+ pictureBox1.Height+40);
             button2.Location = new Point(button2.Location.X, button1.Location.Y - 20);
             button3.Location = new Point(button3.Location.X, button1.Location.Y + 3);
             comboBox1.Location = new Point(comboBox1.Location.X, pictureBox1.Location.Y + pictureBox1.Height + 10);
             radioButton8.Location = new Point(radioButton8.Location.X, pictureBox1.Location.Y + pictureBox1.Height + 40);
             radioButton4.Location = new Point(radioButton4.Location.X, pictureBox1.Location.Y + pictureBox1.Height + 10);
             radioButton5.Location = new Point(radioButton5.Location.X, pictureBox1.Location.Y + pictureBox1.Height + 25);
             radioButton6.Location = new Point(radioButton6.Location.X, pictureBox1.Location.Y + pictureBox1.Height + 40);
             radioButton7.Location = new Point(radioButton7.Location.X, pictureBox1.Location.Y + pictureBox1.Height + 10);


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            int position_save = richTextBox1.SelectionStart; // сохраняем позицию курсора из начально

            int i ;
            for (int b = 0; b < 3; b++)
            {
                i = 0;
                while (i <= richTextBox1.Text.Length - str[b].Length)
                {
                    //выделение цветом
                    i = richTextBox1.Text.IndexOf(str[b], i);
                    if (i < 0) break;
                    color = i;
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = str[b].Length;
                    richTextBox1.SelectionColor = Color.DarkGreen;
                    i += str[b].Length;
                }
            }
            for (int b = 0; b < 3; b++)
            {
                i = 0;
                while (i <= richTextBox1.Text.Length - struser[b].Length)
                {
                    //выделение цветом
                    i = richTextBox1.Text.IndexOf(struser[b], i);
                    if (i < 0) break;
                    color = i;
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = struser[b].Length;
                    richTextBox1.SelectionColor = Color.Blue;
                    i += struser[b].Length;
                }
            }
            string s = "Голос:";
            i = 0;
                while (i <= richTextBox1.Text.Length - s.Length)
                {
                    //выделение цветом
                    i = richTextBox1.Text.IndexOf(s, i);
                    if (i < 0) break;
                    color = i;
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = s.Length;
                    richTextBox1.SelectionColor = Color.Blue;
                    i += s.Length;
                }
            

            string strb = "Первая Битва";
                i = 0;
                while (i <= richTextBox1.Text.Length - strb.Length)
                {
                    //выделение цветом
                    i = richTextBox1.Text.IndexOf(strb, i);
                    if (i < 0) break;
                    color = i;
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = strb.Length;
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                    i += strb.Length;

                }
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.ScrollToCaret();           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (((item == "Успокоительное" && item2 == "") || item2 == "Успокоительное") && antistres > 0)
            {
                madness = 0;
                antistres--;
                t.SetToolTip(pictureBox8, "Успокоительное\n" + Properties.Resources.Успокоительное + "\nКоличество: " + antistres.ToString());
            }
            if (((item == "Травяное зелье" && item2 == "") || item2 == "Травяное зелье") && herbal_potion > 0)
            {
                hp++;
                herbal_potion--;
                if (hp > 3)
                    hp = 3;
                var MyImage = new Bitmap(directory + "\\HP" + hp.ToString() + ".jpg");
                pictureBox3.Image = (Image)MyImage;
                t.SetToolTip(pictureBox9, "Травяное зелье\n" + Properties.Resources.травяное_зелье + "\nКоличество: " + herbal_potion.ToString());

            }
            if (((item == "Магическое зеркало" && item2 == "") || item2 == "Магическое зеркало") && magia ==false)
            {
                magia = true;
                hpboss = hp;
                if (hpboss == 3 || hpboss == 1)
                {
                    for (i = 5 - 1; i >= 1; i--)//Алгоритм Фишера – Йетса
                    {
                        int u = rand.Next(i + 1);
                        int temp = attackbegin[hpboss - 1][u];
                        attackbegin[hpboss - 1][u] = attackbegin[hpboss - 1][i];
                        attackbegin[hpboss - 1][i] = temp;
                    }
                }
                if (hpboss == 2)
                {
                    for (i = 6 - 1; i >= 1; i--)//Алгоритм Фишера – Йетса
                    {
                        int u = rand.Next(i + 1);
                        int temp = attackbegin[hpboss - 1][u];
                        attackbegin[hpboss - 1][u] = attackbegin[hpboss - 1][i];
                        attackbegin[hpboss - 1][i] = temp;
                    }
                }
                var MyImage = new Bitmap(directory + "\\неизвестность" + hpboss.ToString() + ".jpg");
                pictureBox4.Image = (Image)MyImage;
                if (hpboss == 1)
                {
                    timd = timd + 5;
                    if (timd > 10)
                        timd = 10;
                }
            }

                if (((item == "Странный медальон" && item2 == "") || item2 == "Странный медальон") && countmedal == 0)
            {              
                if (comboBox1.Items[0].ToString() == "Защита" || comboBox1.Items[0].ToString() == "Уворот" || comboBox1.Items[0].ToString() == "Защитное действие")
                {                    
                    comboBox1.Text = comboBox1.Items[0].ToString();
                    if (attackbegin[hpboss - 1][count - 1] < 3 && attackbegin[hpboss - 1][count - 1] > 0)//атаки обезглавливание и колесо ужаса
                    {
                        for (int i = 0; i < radioButton.Length; i++)
                        {
                            if (attackDodge[attackbegin[hpboss - 1][count - 1] * 2] == radioButton[i].Text || attackDodge[attackbegin[hpboss - 1][count - 1] * 2 + 1] == radioButton[i].Text)
                            {
                                radioButton[i].ForeColor = Color.Blue;
                                break;
                            }
                        }
                    }
                    else
                    if (attackbegin[hpboss - 1][count - 1] == 0)
                    {

                        for (i = 0; i < radioButton.Length; i++)
                        {
                            if (attackDodge[0] == radioButton[i].Text)
                            {
                                radioButton[i].ForeColor = Color.Blue;
                                break;
                            }
                        }
                    }
                    else
                    if (attackbegin[hpboss - 1][count - 1] == 4)
                    {
                        for (int i = 0; i < radioButton.Length; i++)
                        {
                            if (5 + d == 6)
                            {
                                if (attackDodge[13] == radioButton[i].Text)
                                {
                                    radioButton[i].ForeColor = Color.Blue;
                                    break;
                                }
                            }
                            else
                            if (5 + d == 7)
                            {
                                if (attackDodge[15] == radioButton[i].Text)
                                {
                                    radioButton[i].ForeColor = Color.Blue;
                                    break;
                                }
                            }
                            else
                            if (5 + d == 8)
                            {
                                if (attackDodge[18] == radioButton[i].Text)
                                {
                                    radioButton[i].ForeColor = Color.Blue;
                                    break;
                                }
                            }
                            else
                            if (5 + d == 9)
                            {
                                if (attackDodge[20] == radioButton[i].Text)
                                {
                                    radioButton[i].ForeColor = Color.Blue;
                                    break;
                                }
                            }
                            else
                            {
                                if (attackDodge[22] == radioButton[i].Text)
                                {
                                    radioButton[i].ForeColor = Color.Blue;
                                    break;
                                }
                            }
                        }
                    }
                    else
                        if (attackbegin[hpboss - 1][count - 1] == 3)
                    {
                        for (int i = 0; i < radioButton.Length; i++)
                        {
                            if (combo == 0)
                            {
                                if (attackDodge[6] == radioButton[i].Text)
                                {
                                    radioButton[i].ForeColor = Color.Blue;
                                    break;
                                }
                            }
                            else
                                if (combo == 1)
                            {
                                if (attackDodge[10] == radioButton[i].Text)
                                {
                                    radioButton[i].ForeColor = Color.Blue;
                                    break;
                                }
                            }
                            else
                            if (combo == 2)
                            {
                                if (attackDodge[12] == radioButton[i].Text)
                                {
                                    radioButton[i].ForeColor = Color.Blue;
                                    break;
                                }
                            }
                        }
                    }
                    countmedal = 3;
                }else
                    if (attackbegin[hpboss - 1][count - 1] == 5)
                {
                    for (int i = 0; i < radioButton.Length; i++)
                    {
                        if (otvet[voprosnumber-1] == radioButton[i].Text)
                        {
                            radioButton[i].ForeColor = Color.Blue;
                            break;
                        }
                    }
                }
                else
                    MessageBox.Show("Ничего не происходит");

            }
                else
            if (((item == "Странный медальон" && item2 == "") || item2 == "Странный медальон") && countmedal != 0)
                {
                    MessageBox.Show("Медальон не активен");

                }

            
        }
            private void button2_Click(object sender, EventArgs e)
        {//меч
            if (item == "старый рыцарский меч" && (item2 == "Старая рыцарская броня" || item2 == "Старый рыцарский щит" || item2 == "Бомба" ||  item2 == "Странный медальон"
                || item2 == "Старый журнал" || item2 == "Травяное зелье") ||
         //броня
               item == "Старая рыцарская броня" && (item2 == "старый рыцарский меч" || item2 == "Старый рыцарский щит" || item2 == "Бомба" || item2 == "Странный медальон"
               || item2 == "Старый журнал" || item2 == "Травяное зелье") ||
         //щит
               item == "Старый рыцарский щит" && (item2 == "старый рыцарский меч" || item2 == "Старая рыцарская броня" || item2 == "Бомба" || item2 == "Странный медальон"
               || item2 == "Старый журнал" || item2 == "Травяное зелье") ||
        //бомба
               item == "Бомба" && (item2 == "старый рыцарский меч" || item2 == "Старая рыцарская броня" || item2 == "Старый рыцарский щит" || item2 == "Странный медальон"
               || item2 == "Старый журнал" || item2 == "Успокоительное" || item2 == "Травяное зелье") ||
        //медальон
               item == "Странный медальон" && (item2 == "старый рыцарский меч" || item2 == "Старая рыцарская броня" || item2 == "Старый рыцарский щит" || item2 == "Бомба"
               || item2 == "Успокоительное" || item2 == "Травяное зелье" || item2 == "Старый журнал") ||
        //журнал
               item == "Старый журнал" && (item2 == "старый рыцарский меч" || item2 == "Старая рыцарская броня" || item2 == "Старый рыцарский щит" || item2 == "Бомба"
               || item2 == "Успокоительное" || item2 == "Травяное зелье" || item2 == "Странный медальон") ||
        //успокоительное
               item == "Успокоительное" && (item2 == "Странный медальон" || item2 == "Бомба" || item2 == "Старый журнал") ||
        //травяное зелье
               item == "Травяное зелье" && (item2 == "Странный медальон" || item2 == "Бомба" || item2 == "Старый журнал" || item2 == "Старая рыцарская броня" 
               || item2 == "Старый рыцарский щит" || item2 == "старый рыцарский меч")
               )
                MessageBox.Show("Объединение невозможно");
            if ((item == "Успокоительное" && item2 == "старый рыцарский меч" || item == "старый рыцарский меч" && item2 == "Успокоительное") && antistres>0)
            {
                antistres--;
                if (hpboss==3)
                fhazaone = true;
                t.SetToolTip(pictureBox8, "Успокоительное\n" + Properties.Resources.Успокоительное + "\nКоличество: " + antistres.ToString());
                MessageBox.Show("Объединение успешно");
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

            if (item == "" && item2=="")
            {
                item = "Успокоительное";
            }
            else 
            if (item != "" && item2 != "")
            {
                item = "Успокоительное";
                item2 = "";
            }else
            if (item != "Успокоительное")
                item2 = "Успокоительное";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
                    if (item == "" && item2 == "")
                    {
                        item = "старый рыцарский меч";
                    }
                    else
                   if (item != "" && item2 != "")
                    {
                        item = "старый рыцарский меч";
                        item2 = "";
                    }
                    else
                   if (item != "старый рыцарский меч")
                        item2 = "старый рыцарский меч";
            }       

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (item == "" && item2 == "")
            {
                item = "Бомба";
            }
            else
                   if (item != "" && item2 != "")
            {
                item = "Бомба";
                item2 = "";
            }
            else
                   if (item != "Бомба")
                item2 = "Бомба";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
                if (item == "" && item2 == "")
                {
                    item = "Старая рыцарская броня";
                }
                else
                        if (item != "" && item2 != "")
                {
                    item = "Старая рыцарская броня";
                    item2 = "";
                }
                else
                        if (item != "Старая рыцарская броня")
                    item2 = "Старая рыцарская броня";
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s--;
            label11.Text = (s/100).ToString();
            if (s==0)
            {                
                comboBox1.Text = comboBox1.Items[0].ToString();
                s = 1500;
                if (count > 0)
                {
                    if (attackbegin[hpboss - 1][count - 1] == 3)
                    {
                        if (combo == 1)
                        {
                            hp = hp - 1;
                            combo++;
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackplus[5] + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " +
                                attackopisanie[int.Parse(madness.ToString()), 5] + Environment.NewLine;
                            button1_Click(sender, e);
                        }
                        else
                            if (combo == 0 && comboBox1.Items[0].ToString() != "Атака")
                        {
                            hp = hp - 2;
                            combo = 2;
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackplus[5] + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " +
                                attackopisanie[int.Parse(madness.ToString()), 4] + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Защита персонаж: " + attackplus[5] + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
                            richTextBox1.Text = richTextBox1.Text + "Атака противник: " +
                                attackopisanie[int.Parse(madness.ToString()), 5] + Environment.NewLine;
                            button1_Click(sender, e);
                        }
                        else
                            button1_Click(sender, e);
                    }
                    else
                        button1_Click(sender, e);
                }
                else
                    button1_Click(sender, e);
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (item == "" && item2 == "")
            {
                item = "Странный медальон";
            }
            else
                        if (item != "" && item2 != "")
            {
                item = "Странный медальон";
                item2 = "";
            }
            else
                        if (item != "Странный медальон")
                item2 = "Странный медальон";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (item == "" && item2 == "")
            {
                item = "Старый журнал";
            }
            else
                       if (item != "" && item2 != "")
            {
                item = "Старый журнал";
                item2 = "";
            }
            else
                       if (item != "Старый журнал")
                item2 = "Старый журнал";
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (item == "" && item2 == "")
            {
                item = "Магическое зеркало";
            }
            else
                        if (item != "" && item2 != "")
            {
                item = "Магическое зеркало";
                item2 = "";
            }
            else
                        if (item != "Магическое зеркало")
                item2 = "Магическое зеркало";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (item == "" && item2 == "")
            {
                item = "Старый рыцарский щит";
            }
            else
                        if (item != "" && item2 != "")
            {
                item = "Старый рыцарский щит";
                item2 = "";
            }
            else
                        if (item != "Старый рыцарский щит")
                item2 = "Старый рыцарский щит";
        }


        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (item == "" && item2 == "")
            {
                item = "Травяное зелье";
            }
            else
                        if (item != "" && item2 != "")
            {
                item = "Травяное зелье";
                item2 = "";
            }
            else
                        if (item != "Травяное зелье")
                item2 = "Травяное зелье";
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton4.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = true;
            radioButton8.Visible = true;
            switch (comboBox1.Text)
            {
                case "Атака":
                    if (bomb > 0)
                        radioButton7.Visible = true;
                    radioButton4.Text = "Выпад с мечом";
                    radioButton5.Text = "Горизонтальный удар мечом";
                    radioButton6.Text = "Подготовится к следующей атаке";
                    radioButton7.Text = "Бросок бомбы";
                    radioButton8.Text = "Удар щитом";
                    break;
                case "Уворот":
                    radioButton7.Visible = true;
                    radioButton4.Text = "Отскок";
                    radioButton5.Text = "Кувырок влево";
                    radioButton6.Text = "Кувырок вправо";
                    radioButton7.Text = "Кувырок вперед";
                    radioButton8.Text = "Прыжок";
                    break;
                case "Защита":
                    radioButton7.Visible = true;
                    radioButton4.Text = "Блокировать атаку в левую часть тела";
                    radioButton5.Text = "Блокировать атаку в голову";
                    radioButton6.Text = "Блокировать атаку в ноги";
                    radioButton7.Text = "Блокировать атаку в правую часть тела";
                    radioButton8.Text = "Развернуться и блокировать";
                    break;
                case "Защитное действие": 
                    radioButton7.Visible = true;
                    switch (k)
                    {
                        case 1:
                            radioButton4.Text = "Закрыть глаза";
                            radioButton5.Text = "Отвернуться";
                            radioButton6.Text = "Не Смотреть в глаза";
                            radioButton7.Text = "Успокоиться и собраться с мыслями";
                            radioButton8.Text = "Отходить от него, посматривая на него";
                            break;
                        case 7:
                            radioButton4.Text = "";
                            radioButton5.Text = "";
                            radioButton6.Text = "";
                            radioButton7.Text = "";
                            radioButton8.Text = "";
                            break;
                        case 5:
                            radioButton4.Text = "Прикрыть уши";
                            if (voprosnumber == 1) {
                                radioButton5.Text = "Стремление жить";
                                radioButton6.Text = "Жизнь";
                                radioButton7.Text = "Cтремление выжить";
                                radioButton8.Text = "Долгую жизнь";
                            }
                            else
                                if (voprosnumber == 2) {
                                radioButton5.Text = "4";
                                radioButton6.Text = "7";
                                radioButton7.Text = "6";
                                radioButton8.Text = "5";
                            }else
                                if (voprosnumber == 3)
                            {
                                radioButton5.Text = "Голдор";
                                radioButton6.Text = "Древнор";
                                radioButton7.Text = "Олтор";
                                radioButton8.Text = "Бенор";
                            }
                            else
                                if (voprosnumber == 4)
                            {
                                radioButton5.Text = "";
                                radioButton6.Text = "";
                                radioButton7.Text = "";
                                radioButton8.Text = "";
                            }
                            else
                                if (voprosnumber == 5)
                            {
                                radioButton5.Text = "";
                                radioButton6.Text = "";
                                radioButton7.Text = "";
                                radioButton8.Text = "";
                            }
                            break;
                        case 8:
                            radioButton4.Text = "Двигаться вперед";
                            radioButton5.Text = "Остаться на месте";
                            radioButton6.Text = "";
                            radioButton7.Text = "";
                            radioButton8.Text = "";
                            break;
                    }
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {            
            attackbegin[0] = new int[5] { 0, 1, 2, 3, 4 };
            attackbegin[1] = new int[6] { 0, 1, 2, 3, 4, 5};
            attackbegin[2] = new int[5] { 0, 1, 2, 3, 4 };
            richTextBox1.ReadOnly = true;           
            richTextBox1.ScrollToCaret();
            
            for ( i = 0; i < pictureBoxes.Length; i++)
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
            var MyImage = new Bitmap(directory + "\\герой.jpg");
            pictureBox1.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\сводящий с ума(образец XY).jpg");
            pictureBox2.Image = (Image)MyImage;
            pictureBox3.Location=new Point(pictureBox1.Width/2- pictureBox3.Width/2+ pictureBox1.Location.X, pictureBox1.Location.Y - pictureBox3.Height);
            pictureBox4.Location = new Point(pictureBox2.Width / 2 - pictureBox4.Width / 2 + pictureBox2.Location.X, pictureBox2.Location.Y - pictureBox4.Height);
            MyImage = new Bitmap(directory + "\\неизвестность.jpg");
            pictureBox4.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\HP3.jpg");
            pictureBox3.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\Успокоительное.jpg");
            pictureBox8.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\Старый рыцарский щит.jpg");
            pictureBox7.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\старый рыцарский меч.jpg");
            pictureBox5.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\Бомба.jpg");
            pictureBox6.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\Старая рыцарская броня.jpg");
            pictureBox10.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\травяное зелье.jpg");
            pictureBox9.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\медальон.jpg");
            pictureBox17.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\журнал.jpg");
            pictureBox12.Image = (Image)MyImage;
            MyImage = new Bitmap(directory + "\\магическое зеркало.jpg");
            pictureBox15.Image = (Image)MyImage;
            label1.Dock = DockStyle.Top;
            label1.TextAlign = ContentAlignment.MiddleCenter;           
            t.SetToolTip(pictureBox8, "Успокоительное\n" + Properties.Resources.Успокоительное+"\nКоличество: "+antistres.ToString());
            comboBox1.Items.Clear();           
            richTextBox1.Text = "Первая Битва" + Environment.NewLine;
            comboBox1.Items.AddRange(new object[]
                   {"Атака"});          
            t.SetToolTip(pictureBox7, "Старый рыцарский щит\n" + Properties.Resources.Старый_рыцарский_щит);
            t.SetToolTip(pictureBox6, "Бомба\n" + Properties.Resources.Бомба+"\nКоличество: "+bomb.ToString());
            t.SetToolTip(pictureBox5, "Старый рыцарский меч\n" + Properties.Resources.старый_рыцарский_меч);
            t.SetToolTip(pictureBox9, "Травяное зелье\n" + Properties.Resources.травяное_зелье + "\nКоличество: " + herbal_potion.ToString());
            t.SetToolTip(pictureBox17, "Странный медальон\n" + Properties.Resources.медальон);
            t.SetToolTip(pictureBox12, "Странный медальон\n" + Properties.Resources.журнал);
            t.SetToolTip(pictureBox15, "Странный медальон\n" + Properties.Resources.Магическое_зеркало);
            for (int i = 5 - 1; i >= 1; i--)//Алгоритм Фишера – Йетса
            {
                int u = rand.Next(i + 1);
                int temp = attackbegin[hpboss-1][u];
                attackbegin[hpboss - 1][u] = attackbegin[hpboss - 1][i];
                attackbegin[hpboss - 1][i] = temp;
            }
           

        }
    }
}
