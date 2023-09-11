using System;


namespace DataStructures
{

    public class GeneralNode<G>
    {
        private G data;
       
        public GeneralNode(G data)
        {
            this.data = data;
        }


        public G Data
        {
            get { return data;  }
            set { data = value; }  
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType() || this.data == null)
            {
                return false;
            }
            else
            {
                return data.Equals(((GeneralNode<G>)obj).data);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
