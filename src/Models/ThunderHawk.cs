using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
  public class ThunderHawk : Model
  {
    private int _counter = 100;
    private bool _thunderhawkHere = false;
    private bool _thunderhawkEmpty = false;

    public bool thunderhawkHere { get { return _thunderhawkHere; } }
    public bool thunderhawkEmpty { get { return _thunderhawkEmpty; } }

    public ThunderHawk(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base("thunderhawk", x, y, z, rotationX, rotationY, rotationZ)
    {

    }

    public void ChangeThunderhawkHere(bool b)
    {
      this._thunderhawkHere = b;
    }

    public void ChangeThunderhawkEmpty(bool b)
    {
      this._thunderhawkEmpty = b;
    }

    public override bool Update(int tick)
    {
      if (this.x == -20)
      {
        ChangeThunderhawkHere(true);
      }
      else
      {
        ChangeThunderhawkHere(false);
      }

      if (_thunderhawkHere && !_thunderhawkEmpty)
      {

      }

      else if (!_thunderhawkHere && !_thunderhawkEmpty)
      {
        this.Move(this.x + 1, this.y, this.z);
      }

      else if (_thunderhawkEmpty == true)
      {
        if (_counter <= 0)
        {
          this.Move(this.x + 2, this.y, this.z);
          ChangeThunderhawkHere(false);
        }

        _counter--;
      }

      else
      {
      }

      return base.Update(tick);

    }

    public void RESET()
    {
      ChangeThunderhawkEmpty(false);
      ChangeThunderhawkHere(false);
      this.Move(-150, this.y, this.z);
    }
  }
}
