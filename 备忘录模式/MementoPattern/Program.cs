using System;
using System.Collections.Generic;
namespace MementoPattern
{
    class Program
    {
        /// <summary>
        /// 需要备份的数据
        /// </summary>
        public sealed class MemetoObj
        {
            //姓名
            public string Name { get; set; }

            //事情
            public string MemetoStr { get; set; }
        }
     // 发起人--相当于【发起人角色】Originator
    public sealed class MemetoOriginator
    {
        // 发起人需要保存的内部状态
        private List<MemetoObj> _memetoList;


        public List<MemetoObj> MemetoList
        {
            get
            {
                return this._memetoList;
            }

            set
            {
                this._memetoList = value;
            }
        }
       
        public MemetoOriginator(List<MemetoObj> memetoList)
        {
            if (memetoList != null)
            {
                this._memetoList = memetoList;
            }
            else
            {
                throw new ArgumentNullException("参数不能为空！");
            }
        }

        // 创建备忘录对象实例，将当期要保存的联系人列表保存到备忘录对象中
        public Memento CreateMemento()
        {
            return new Memento(new List<MemetoObj>(this._memetoList));
        }

        // 将备忘录中的数据备份还原到联系人列表中
        public void RestoreMemento(Memento memento)
        {
            this.MemetoList = memento.MementoListBack;
        }

        public void Show()
        {
            Console.WriteLine("备忘列表中共有{0}个人，他们是:", MemetoList.Count);
            foreach (MemetoObj p in MemetoList)
            {
                Console.WriteLine("姓名: {0} 备忘: {1}", p.Name, p.MemetoStr);
            }
        }
    }
 // 备忘录对象，用于保存状态数据，保存的是当时对象具体状态数据--相当于【备忘录角色】Memeto
    public sealed class Memento
    {
        // 保存发起人创建的数据，就是所谓的状态
        public List<MemetoObj> MementoListBack { get; private set; }

        public Memento(List<MemetoObj> personList)
        {
            MementoListBack = personList;
        }
    }

    // 管理角色，它可以管理【备忘录】对象
    public sealed class MementoManager
    {
        //如果想保存多个【备忘录】对象，可以通过字典或者堆栈来保存
        public Memento Memento { get; set; }
    }
        static void Main(string[] args)
        {
            List<MemetoObj> persons = new List<MemetoObj>()
            {
                new MemetoObj() { Name="素还真", MemetoStr = "找大师"},
                new MemetoObj() { Name="一页书", MemetoStr = "笑尽英雄"},
                new MemetoObj() { Name="叶小钗", MemetoStr = "刀狂剑痴"}
            };

            //手机名单发起人
            MemetoOriginator mobileOriginator = new MemetoOriginator(persons);
            mobileOriginator.Show();

            // 创建备忘录并保存备忘录对象
            MementoManager manager = new MementoManager();
            manager.Memento = mobileOriginator.CreateMemento();

            // 更改发起人联系人列表
            Console.WriteLine("----移除最后一个联系人--------");
            mobileOriginator.MemetoList.RemoveAt(2);
            mobileOriginator.Show();

            // 恢复到原始状态
            Console.WriteLine("-------恢复联系人列表------");
            mobileOriginator.RestoreMemento(manager.Memento);
            mobileOriginator.Show();

            Console.WriteLine("Hello World!");
        }
    }
}
