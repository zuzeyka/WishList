using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace ListviewExample
{
    public partial class Form1 : Form
    {
        ListView listView1;
        public Form1()
        {
            InitializeComponent();
            // Создаем новый ListView
            listView1 = new ListView();

            // Зададим размер и местоположение списка на форме
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

            // Установим табличный режим отображения
            listView1.View = View.Details;

            // Позволим пользователю редактировать поле элемента списка
            listView1.LabelEdit = true;

            // Позволим пользователю перемещать столбцы в табличном режиме
            listView1.AllowColumnReorder = true;

            // Возле каждого элемента списка будет флажок
            listView1.CheckBoxes = true;

            // При выборе элемента списка будет подсвечена вся строка
            listView1.FullRowSelect = true;

            // Отобразим линии сетки в табличном режиме
            listView1.GridLines = true;

            // Установим сортировку элементов в порядке возрастания
            listView1.Sorting = SortOrder.Ascending;

            // Создадим три элемента списка и три подэлемента для каждого из них 
            List<ListViewItem> item = new List<ListViewItem>();
            StreamReader streamReader = new StreamReader("text.txt");
            listView1.Columns.Add("Wish Item", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Price", 60, HorizontalAlignment.Left);
            int counter = 0;
            do
            {
                string name = Convert.ToString(streamReader.ReadLine());
                item.Add(new ListViewItem(name, 0));
                string price = Convert.ToString(streamReader.ReadLine());
                item[counter].Checked = true; // Флажок элемента списка будет включен
                item[counter].SubItems.Add(price);
                listView1.Items.Add(item[counter]);
                counter++;

            } while (!streamReader.EndOfStream);
            streamReader.Close();
            // Создадим колонки (1 параметр - название столбца, 2 параметр - ширина столбца, выравнивание названия)

            // Добавляем элементы в список

            // Создаем два пустых списка изображений для больших и малых значков
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();
            // Инициализируем списки изображений картинками
            imageListSmall.Images.Add(Image.FromFile("present.jfif"));
            imageListLarge.Images.Add(Image.FromFile("present.jfif"));

            // ассоциируем списки изображений с ListView
            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;

            // Добавляем ListView в коллекцию элементов управления
            this.Controls.Add(listView1);

            Width = 200; // Ширина формы
            Height = 250; // Высота формы
        }
    }
}