using System;
using System.Collections.Generic;

namespace BT_DB_First.Models;

public partial class TbDanhmucvanphongpham
{
    public int Maloai { get; set; }

    public string Tenloai { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual ICollection<TbVanphongpham> TbVanphongphams { get; set; } = new List<TbVanphongpham>();
}
