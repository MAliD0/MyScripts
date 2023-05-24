using System;

public struct GridPosition 
{
    int x; int z;
    public GridPosition(int x, int z) {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return "x "+x+" ;" + "z " + z;
    }

    public int getX()
    {
        return x;
    }
    public int getZ()
    {
        return z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position &&
               x == position.x &&
               z == position.z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.getX() == b.getX() && a.getZ() == b.getZ();
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return a.getX() != b.getX() || a.getZ() != b.getZ();
    }

    public static GridPosition operator -(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.getX() - b.getX(),a.getZ() - b.getZ());
    }
    public static GridPosition operator +(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.getX() + b.getX(), a.getZ() + b.getZ());
    }
}
