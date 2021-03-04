
/*
Copyright (C) 2019-2020 TARAKHOMYN YURIY IVANOVYCH
All rights reserved.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

/*
Автор:    Тарахомин Юрій Іванович
Адреса:   Україна, м. Львів
Сайт:     accounting.org.ua
*/
  
/*
 *
 * Конфігурації "Нова конфігурація"
 * Автор 
  
 * Дата конфігурації: 04.03.2021 12:24:05
 *
 */

using System;
using System.Collections.Generic;
using AccountingSoftware;

namespace НоваКонфігурація_1_0
{
    static class Config
    {
        public static Kernel Kernel { get; set; }
        
    }
}

namespace НоваКонфігурація_1_0.Константи
{
    
}

namespace НоваКонфігурація_1_0.Довідники
{
    
    #region DIRECTORY "Тест"
    
    class Тест_Objest : DirectoryObject
    {
        public Тест_Objest() : base(Config.Kernel, "tab_a01",
             new string[] { "col_a1", "col_a2" }) 
        {
            Назва = "";
            Код = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Код = base.FieldValue["col_a2"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a2"] = Код;
            
            BaseSave();
        }

        public string Serialize()
        {
            return 
            "<Тест>" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "</Тест>";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Тест_Pointer GetDirectoryPointer()
        {
            Тест_Pointer directoryPointer = new Тест_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        
    }
    
    
    class Тест_Pointer : DirectoryPointer
    {
        public Тест_Pointer(object uid = null) : base(Config.Kernel, "tab_a01")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Тест_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a01")
        {
            base.Init(uid, fields);
        }
        
        public Тест_Objest GetDirectoryObject()
        {
            Тест_Objest ТестObjestItem = new Тест_Objest();
            return ТестObjestItem.Read(base.UnigueID) ? ТестObjestItem : null;
        }
    }
    
    
    class Тест_Select : DirectorySelect, IDisposable
    {
        public Тест_Select() : base(Config.Kernel, "tab_a01",
            new string[] { "col_a1", "col_a2" },
            new string[] { "Назва", "Код" }) { }
        
        public const string Назва = "col_a1";
        public const string Код = "col_a2";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Тест_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Тест_Pointer Current { get; private set; }
        
        public Тест_Pointer FindByField(string name, object value)
        {
            Тест_Pointer itemPointer = new Тест_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Тест_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Тест_Pointer> directoryPointerList = new List<Тест_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Тест_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      ///<summary>
    ///Список.
    ///</summary>
    class Тест_Список_View : DirectoryView
    {
        public Тест_Список_View() : base(Config.Kernel, "tab_a01", 
             new string[] { "col_a1", "col_a2" },
             new string[] { "Назва", "Код" },
             new string[] { "string", "string" },
             "Довідник_Тест_Список")
        {
            
        }
        
    }
      
    
    #endregion
    
    #region DIRECTORY "Тест2"
    ///<summary>
    ///кенуек.
    ///</summary>
    class Тест2_Objest : DirectoryObject
    {
        public Тест2_Objest() : base(Config.Kernel, "tab_a02",
             new string[] { "col_a1", "col_a2", "col_a3" }) 
        {
            Назва = "";
            Код = "";
            ТестІд = new Довідники.Тест_Pointer();
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Код = base.FieldValue["col_a2"].ToString();
                ТестІд = new Довідники.Тест_Pointer(base.FieldValue["col_a3"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a2"] = Код;
            base.FieldValue["col_a3"] = ТестІд.UnigueID.UGuid;
            
            BaseSave();
        }

        public string Serialize()
        {
            return 
            "<Тест2>" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "<ТестІд>" + ТестІд.ToString() + "</ТестІд>"  +
               "</Тест2>";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Тест2_Pointer GetDirectoryPointer()
        {
            Тест2_Pointer directoryPointer = new Тест2_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        public Довідники.Тест_Pointer ТестІд { get; set; }
        
    }
    
    ///<summary>
    ///кенуек.
    ///</summary>
    class Тест2_Pointer : DirectoryPointer
    {
        public Тест2_Pointer(object uid = null) : base(Config.Kernel, "tab_a02")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Тест2_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a02")
        {
            base.Init(uid, fields);
        }
        
        public Тест2_Objest GetDirectoryObject()
        {
            Тест2_Objest Тест2ObjestItem = new Тест2_Objest();
            return Тест2ObjestItem.Read(base.UnigueID) ? Тест2ObjestItem : null;
        }
    }
    
    ///<summary>
    ///кенуек.
    ///</summary>
    class Тест2_Select : DirectorySelect, IDisposable
    {
        public Тест2_Select() : base(Config.Kernel, "tab_a02",
            new string[] { "col_a1", "col_a2", "col_a3" },
            new string[] { "Назва", "Код", "ТестІд" }) { }
        
        public const string Назва = "col_a1";
        public const string Код = "col_a2";
        public const string ТестІд = "col_a3";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Тест2_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Тест2_Pointer Current { get; private set; }
        
        public Тест2_Pointer FindByField(string name, object value)
        {
            Тест2_Pointer itemPointer = new Тест2_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Тест2_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Тест2_Pointer> directoryPointerList = new List<Тест2_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Тест2_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      ///<summary>
    ///Список.
    ///</summary>
    class Тест2_Список_View : DirectoryView
    {
        public Тест2_Список_View() : base(Config.Kernel, "tab_a02", 
             new string[] { "col_a1", "col_a2" },
             new string[] { "Назва", "Код" },
             new string[] { "string", "string" },
             "Довідник_Тест2_Список")
        {
            
        }
        
    }
      
    
    #endregion
    
}

namespace НоваКонфігурація_1_0.Перелічення
{
    
}

namespace НоваКонфігурація_1_0.Документи
{
    
}

namespace НоваКонфігурація_1_0.Журнали
{

}

namespace НоваКонфігурація_1_0.РегістриВідомостей
{
    
}

namespace НоваКонфігурація_1_0.РегістриНакопичення
{
    
}
  