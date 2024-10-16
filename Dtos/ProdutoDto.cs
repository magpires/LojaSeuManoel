using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class ProdutoDto
    {
        public string Produto_Id { get; set; } = string.Empty;
        public DimensoesDto Dimensoes { get; set; } = new DimensoesDto();
    }
}
