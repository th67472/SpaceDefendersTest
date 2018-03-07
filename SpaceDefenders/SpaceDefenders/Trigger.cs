using System;
namespace SpaceDefenders
{

    public class Trigger
    {
        int threshold;

        public int Threshold 
        {
            set
            {
                threshold = value;
                Count = value;
            }

            private get
            {
                return threshold;
            }
        }

        int Count;

        public delegate void TriggerEventHandler();
        public event TriggerEventHandler Triggered;

        public Trigger() : this(1) { }

        public Trigger(int threshold)
        {
            Threshold = threshold;
        }

        public void Tick()
        {
            if (Count == 0)
            {
                Count = Threshold;
                Triggered?.Invoke();
            }

            Count--;
        }
    }
}
