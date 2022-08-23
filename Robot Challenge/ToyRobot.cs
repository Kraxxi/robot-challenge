namespace Robot_Challenge
{
    public class ToyRobot
    {
        public Vector2 Direction { get; private set; }
        public Vector2 Position { get; private set; }
        public Tabletop Tabletop { get; private set; }


        //Set the tabletop
        public void SetTabletop(Tabletop tabletop)
        {
            Tabletop = tabletop;
        }

        //Set the position of the robot
        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        //Set the direction/rotation of the robot
        public void SetDirection(Vector2 direction)
        {
            Direction = direction;
        }

        public void Move()
        {
            //Calculate destination
            Vector2 destination = Position + Direction;

            //Only allow moving if within bounds and if we have ben assigned a tabletop
            if (Tabletop == null || !Tabletop.IsValidPosition(destination)) return;

            //Move!
            SetPosition(destination);
        }
    }
}
