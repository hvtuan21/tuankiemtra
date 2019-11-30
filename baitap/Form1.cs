using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace baitap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            loaddata();

        }
        void loaddata()
        {
            using (qlsvEntities db = new qlsvEntities())
            {
                var result = from s in db.sv select s;
                listView1.Items.Clear();
                listView1.Groups.Clear();
                ListViewGroup lvan = new ListViewGroup("Khoa Văn");
                listView1.Groups.Add(lvan);
                ListViewGroup lvatly = new ListViewGroup("Khoa Vật Lý");
                listView1.Groups.Add(lvatly);
                ListViewGroup lcntt = new ListViewGroup("Khoa Công Nghệ Thông Tin");
                listView1.Groups.Add(lcntt);
                foreach (var data in result)
                {
                    DateTime dd = (DateTime)data.ngaysinh;
                    ListViewItem lvi = new ListViewItem(data.tensv);
                    lvi.SubItems.Add(dd.ToString("dd'/'MM'/'yyyy"));
                    lvi.SubItems.Add(data.gioitinh);
                    lvi.SubItems.Add(data.diem1.ToString());
                    lvi.SubItems.Add(data.diem2.ToString());
                    lvi.SubItems.Add(data.diem3.ToString());
                    lvi.SubItems.Add(data.diem4.ToString());
                    lvi.SubItems.Add(data.khoa);

                    float dtb = (float)(data.diem1 + data.diem2 + data.diem3 + data.diem4) / 4;
                    lvi.SubItems.Add(dtb + "");
                    lvi.SubItems.Add(data.masv);
                    listView1.Items.Add(lvi);
                    if (string.Compare(data.khoa, "CNTT", true) == 0)
                        lvi.Group = lcntt;
                    if (string.Compare(data.khoa, "VATLY", true) == 0)
                        lvi.Group = lvatly;
                    if (string.Compare(data.khoa, "VAN", true) == 0)
                        lvi.Group = lvan;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem lv in listView1.SelectedItems)
            {
                txthten.Text = lv.SubItems[0].Text;
                if (lv.SubItems[2].Text == "Nam")
                    radnam.Checked = true;
                else if (lv.SubItems[2].Text == "Nữ")
                   radnu.Checked = true;
                   txtngaysinh.Text = lv.SubItems[1].Text;
                txtma.Text = lv.SubItems[9].Text;
               if(lv.SubItems[7].Text=="VAN")
                {
                    txtcd.Text = lv.SubItems[3].Text;
                    txthd.Text = lv.SubItems[4].Text;
                    txtvhdc.Text = lv.SubItems[5].Text;
                    txtnv10.Text = lv.SubItems[6].Text;
                    txtpc.Text = "";
                    txtc.Text = "";
                    txtsql.Text = "";
                    txtjava.Text = "";
                    txtch.Text = "";
                    txtqh.Text = "";
                    txtd.Text = "";
                    txthn.Text = "";                    
                }
                if (lv.SubItems[7].Text == "CNTT")
                {
                    txtcd.Text = "";
                    txthd.Text = "";
                    txtvhdc.Text = "";
                    txtnv10.Text = "";
                    txtch.Text = "";
                    txtqh.Text = "";
                    txtd.Text = "";
                    txthn.Text = "";
                    txtpc.Text = lv.SubItems[3].Text;
                    txtc.Text = lv.SubItems[4].Text;
                    txtsql.Text = lv.SubItems[5].Text;
                    txtjava.Text = lv.SubItems[6].Text;               
                }
                if (lv.SubItems[7].Text == "VATLY")
                {
                    txtcd.Text = "";
                    txthd.Text = "";
                    txtvhdc.Text = "";
                    txtnv10.Text = "";

                    txtpc.Text = "";
                    txtc.Text = "";
                    txtsql.Text = "";
                    txtjava.Text = "";

                    txtch.Text = lv.SubItems[3].Text;
                    txtqh.Text = lv.SubItems[4].Text;
                    txtd.Text = lv.SubItems[5].Text;
                    txthn.Text = lv.SubItems[6].Text;
                }

                txtdtb.Text = lv.SubItems[8].Text;

            }
        }

        private void btntaomoi_Click(object sender, EventArgs e)
        {
            txtcd.Text = "";
            txthd.Text = "";
            txtvhdc.Text = "";
            txtnv10.Text = "";

            txtpc.Text = "";
            txtc.Text = "";
            txtsql.Text = "";
            txtjava.Text = "";
            txtch.Text = "";
            txtqh.Text = "";
            txtd.Text = "";
            txthn.Text = "";
            txthten.Text = "";
            txtngaysinh.Text = "";
            txtdtb.Text = "";
            txtma.Text = "";
        }

        private void bsvan_Click(object sender, EventArgs e)
        {
            using (qlsvEntities sb = new qlsvEntities())
            {
                sv svv = new sv();
                svv.masv = txtma.Text;
                svv.tensv = txthten.Text;
                DateTime dt = Convert.ToDateTime(txtngaysinh.Text);
                svv.ngaysinh = dt;
                if(radnam.Checked==true)
                {
                    svv.gioitinh = "Nam";
                }
                if (radnu.Checked == true)
                {
                    svv.gioitinh = "Nữ";
                }
                svv.khoa = "VAN";
                svv.diem1 = float.Parse(txtcd.Text);
                svv.diem2 = float.Parse(txthd.Text);
                svv.diem3 = float.Parse(txtvhdc.Text);
                svv.diem4 = float.Parse(txtnv10.Text);
                sb.sv.Add(svv);
                sb.SaveChanges();
                loaddata();
            }
        }

        private void bsvl_Click(object sender, EventArgs e)
        {
            using (qlsvEntities sb = new qlsvEntities())
            {
                sv svv = new sv();
                svv.masv = txtma.Text;
                svv.tensv = txthten.Text;
                DateTime dt = Convert.ToDateTime(txtngaysinh.Text);
                svv.ngaysinh = dt;
                if (radnam.Checked == true)
                {
                    svv.gioitinh = "Nam";
                }
                if (radnu.Checked == true)
                {
                    svv.gioitinh = "Nữ";
                }
                svv.khoa = "VATLY";
                svv.diem1 = float.Parse(txtch.Text);
                svv.diem2 = float.Parse(txtqh.Text);
                svv.diem3 = float.Parse(txtd.Text);
                svv.diem4 = float.Parse(txthn.Text);
                sb.sv.Add(svv);
                sb.SaveChanges();
                loaddata();
            }
        }
      
        private void bscntt_Click(object sender, EventArgs e)
        {
            using (qlsvEntities sb = new qlsvEntities())
            {
                sv svv = new sv();
                svv.masv = txtma.Text;
                svv.tensv = txthten.Text;
                DateTime dt = Convert.ToDateTime(txtngaysinh.Text);
                svv.ngaysinh = dt;
                if (radnam.Checked == true)
                {
                    svv.gioitinh = "Nam";
                }
                if (radnu.Checked == true)
                {
                    svv.gioitinh = "Nữ";
                }
                svv.khoa = "CNTT";
                svv.diem1 = float.Parse(txtpc.Text);
                svv.diem2 = float.Parse(txtc.Text);
                svv.diem3 = float.Parse(txtsql.Text);
                svv.diem4 = float.Parse(txtjava.Text);
                sb.sv.Add(svv);
                sb.SaveChanges();
                loaddata();
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            using (qlsvEntities db = new qlsvEntities())
            {
                string ma = txtma.Text;
                sv s = db.sv.Where(p => p.masv == ma).SingleOrDefault();
                db.sv.Remove(s);
                db.SaveChanges();
                loaddata();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            using (qlsvEntities db = new qlsvEntities())
            {
                string ma = txtma.Text;
                
                sv s = db.sv.Where(p => p.masv == ma).SingleOrDefault();
                s.tensv = txthten.Text;
                DateTime dt = Convert.ToDateTime(txtngaysinh.Text);
                s.ngaysinh = dt;
                if(s.khoa=="VAN")
                {
                    s.diem1 = float.Parse(txtcd.Text);
                    s.diem2 = float.Parse(txthd.Text);
                    s.diem3 = float.Parse(txtvhdc.Text);
                    s.diem4 = float.Parse(txtnv10.Text);
                }
               
                if (s.khoa == "CNTT")
                {
                    s.diem1 = float.Parse(txtpc.Text);
                    s.diem2 = float.Parse(txtc.Text);
                    s.diem3 = float.Parse(txtsql.Text);
                    s.diem4 = float.Parse(txtjava.Text);
                }
                
                if (s.khoa == "VATLY")
                {
                    s.diem1 = float.Parse(txtch.Text);
                    s.diem2 = float.Parse(txtqh.Text);
                    s.diem3 = float.Parse(txtd.Text);
                    s.diem4 = float.Parse(txthn.Text);
                }
               
                db.SaveChanges();
                loaddata();
            }
        }
    }
}
