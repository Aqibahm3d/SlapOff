// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("x9lmk+GQU8/pksT4cberSxcrH0lqwcIv3UeK4HTc5O0aIq7Y+lqBt3yjpU/7wQ76CV2Cg8dGNvc7U89z9QOgsuUOddhLbCf65jnKj4+DQILxuU2QG3zKxW+5NUCinbjJXjAEEJUnpIeVqKOsjyPtI1KopKSkoKWm9hvOnu9hJ1r1dvZ1aCn3je7j0EAnpKqllSekr6cnpKSlfGGYNPWOelBwdT9emhTbVZVK/nULlHDuLGth1MegZyARJkQN8lJU24YBUfjjO8TPgbCl4Vm6/YM0BO6QMCV4t5DN1RNWQRPFlyj+dCySNpAgzpYZmT5LODs2sjjU9+ZXqn0TpAYkucmmx4k/yxShbpjpdpjvCsoJJKVjKM12oqm7f3Fz6flhIqempKWk");
        private static int[] order = new int[] { 8,7,13,4,11,8,10,7,12,11,10,13,13,13,14 };
        private static int key = 165;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
