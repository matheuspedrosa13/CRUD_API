namespace CrudOfertas.Api.Repositorios.Implementacoes;
using CrudOfertas.Api.Repositorios.DAOs;
using CrudOfertas.Api.Servicos.DTOs;
using CrudOfertas.Api.Infraestrutura;
using CrudOfertas.Api.Repositorios.Interfaces;
public class OfertaRepository  : IOfertaRepository
{
        private readonly List<OfertaDAO> _ofertas;

        public OfertaRepository()
        {
            _ofertas = OfertaDatabase.ObterOfertas();
        }

        public List<OfertaDAO> ObterTodasOfertas()
        {
            return _ofertas;
        }

        public OfertaDAO ObterOfertaPorId(int id)
        {
            return _ofertas.FirstOrDefault(o => o.Id == id)!;
        }

        public void AdicionarOferta(OfertaDAO oferta)
        {

            _ofertas.Add(oferta);
        }

        public int TamanhoDatabase(){
            int id = OfertaDatabase.TamanhoDatabase();
            return id;
        }

        public void AtualizarOferta(OfertaDAO oferta)
        {
            var ofertaExistente = _ofertas.FirstOrDefault(o => o.Id == oferta.Id);
            if (ofertaExistente != null)
            {
                // Atualize os campos necessários da oferta existente
                ofertaExistente.PorcentagemEmissao = oferta.PorcentagemEmissao;
                ofertaExistente.PorcentagemDistribuicao = oferta.PorcentagemDistribuicao;
                ofertaExistente.TaxaEmissao = oferta.TaxaEmissao;
                // ... (atualize os outros campos)

                // Atualize a data de atualização
                ofertaExistente.DataAtualizacao = DateTime.Now;
            }
        }

        public void RemoverOferta(int id)
        {
            var ofertaExistente = _ofertas.FirstOrDefault(o => o.Id == id);
            if (ofertaExistente != null)
            {
                _ofertas.Remove(ofertaExistente);
            }
        }
    }
