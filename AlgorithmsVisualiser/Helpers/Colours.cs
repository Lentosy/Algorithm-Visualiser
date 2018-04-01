
using System.Windows.Media;

namespace AlgorithmsVisualiser.Helpers
{
    /*
     * Important colours used in the application. Mind the british spelling 
     */
    public class Colours
    {
        public static Color Default {
            get {
                return Color.FromArgb(255, 0, 0, 0);
            }
        }
        public static Color Red {
            get {
                return Color.FromArgb(255, 255, 0, 0);
            }
        }
        
        public static Color Green {
            get {
                return Color.FromArgb(255, 0, 255, 0);
            }
        }

        public static Color Blue {
            get {
                return Color.FromArgb(255, 0, 0, 255);
            }
        }
    }
}
