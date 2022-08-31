namespace Robot_Challenge
{
    public class ToyRobot
    {
        public Vector2 Direction { get; private set; }
        public Vector2 Position { get; private set; }
        public Tabletop Tabletop { get; private set; }
        public int MoveSpeed { get; private set; }


        public ToyRobot()
        {
            MoveSpeed = 1;
        }

        //Strafes left perpendicular to the direction
        public void StrafeLeft()
        {
            Vector2 strafeDirection = Vector2.RotateLeft(Direction);

            Move(strafeDirection);
        }

        //Strafes right perpendicular to the direction
        public void StrafeRight()
        {
            Vector2 strafeDirection = Vector2.RotateRight(Direction);

            Move(strafeDirection);
        }

        //Move as far forward as possible without falling off
        public void Charge()
        {
            Vector2 currentPosition;
            int oldMoveSpeed = MoveSpeed;

            SetMoveSpeed(1);

            do
            {
                currentPosition = Position;
                Move();

            } while (currentPosition != Position);

            SetMoveSpeed(oldMoveSpeed);
        }

        //Set the movement speed
        public void SetMoveSpeed(int speed)
        {
            MoveSpeed = speed;
        }

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

        public string GetMoveMode()
        {
            return MoveSpeed == 1 ? "WALK" : "RUN";
        }

        public void Move() => Move(Direction);

        public void Move(Vector2 direction)
        {
            //Calculate destination
            Vector2 destination = Position + (direction * MoveSpeed);

            //Only allow moving if within bounds and if we have ben assigned a tabletop
            if (Tabletop == null || !Tabletop.IsValidPosition(destination)) return;

            //Move!
            SetPosition(destination);
        }
    }
}
