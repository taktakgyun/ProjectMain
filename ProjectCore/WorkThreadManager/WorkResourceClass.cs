namespace Mainboard
{
	using System;
	using Netonsoft.Json;
	using System.Collections.Generic;

	/// <summary>
	/// work resouce의 내용을 담을 수 있는 container
	/// </summary>
	interface IJObjectUseAbleContainer
    {
		public JObject GetJObject();
		public void SetJOjbect(JObject obj);
		public string GetKey();
    }

	abstract class CompoundContainer :IJObjectUseAbleContainer
    {
		abstract public string GetKey();
		abstract public void SetJObject(JObject obj);
		public JObject GetJObject()
        {
			JObject obj = new JObject();
			foreach(IJObjectUseAbleContainer container in containers)
			{
				obj.Add(container.GetKey(), container.GetJObject()[container.GetKey()]);
            }
			JObject json = new JObject();
			json.Add(GetKey(), obj);
			return json;
        }
		protected List<IJObjectUseAbleContainer> containers;
    }

	class ClassficationContainer : IJObjectUseAbleContainer
    {
		
		public ClassficationContainer(string classfication=null)
        {
			this.classfication = classfication;
        }
		public string GetKey() { return "classfication"; }
		public JObject GetJObject()
        {
			if (classfication == null) throw NullReferenceException;
			JObject json = new JObject();
			json.Add(GetKey(), classfication);
			return json;
        }
		public void SetJObject(JObject obj)
        {
			classfication = obj[GetKey()];
		}
		public void SetClassfication(string classfication)
        {
			this.classfication = classfication;
        }
		protected string classfication;
	}

	class BoundBoxContainer : IJObjectUseAbleContainer
    {
		public BoundBoxContainer(int x_min=0, int x_max=0, int y_min=0, int y_max=0)
        {
			SetBoundBox(x_min, x_max, y_min, y_max);
		}
		public JObject GetJObject()
		{
			if (boundbox[0]+ boundbox[1]+ boundbox[2]+ boundbox[3] =< 0) throw NullReferenceException;
			JObject json = new JObject();
			json.Add(GetKey(), boundbox);
			return json;
		}
		public void SetJObject(JObject obj)
		{
			 = obj[GetKey()];
		}
		public void SetBoundBox(int x_min, int x_max, int y_min, int y_max)
        {
			this.boundbox[0] = x_min;
			this.boundbox[1] = x_max;
			this.boundbox[2] = y_min;
			this.boundbox[3] = y_max;
		}

		public string GetKey() { return "boundbox"; }

		/// <summary>
        /// 0:x_min / 1:x_max / 2:y_min / 3:y_max
        /// </summary>
		protected int[4] boundbox;
    }
	public class WorkResourceClass
	{
		public WorkResourceClass()
		{
		}
	}
}


