using System;
using System.Collections.Generic;

namespace BT_DB_First.Models;

public partial class TbVanphongpham
{
    public int Mavanphongpham { get; set; }

    public string Tenvanphongpham { get; set; } = null!;

    public string? Mota { get; set; }

    public int? Maloai { get; set; }

    public virtual TbDanhmucvanphongpham? MaloaiNavigation { get; set; }
}
