// using CrudOfertas.Api.Servicos.Interfaces;

// namespace CrudOfertas.Api.Servicos.Implementacoes;

//     public class OfertaService : IOfertaService
//     {
//         private readonly IOfertaRepository _ofertaRepository;
//         private readonly IMapper _mapper;

//         public OfertaService(IOfertaRepository ofertaRepository, IMapper mapper)
//         {
//             _ofertaRepository = ofertaRepository;
//             _mapper = mapper;
//         }

//         public List<OfertaDTO> ObterTodasOfertas()
//         {
//             var ofertasDAO = _ofertaRepository.ObterTodasOfertas();
//             return _mapper.Map<List<OfertaDTO>>(ofertasDAO);
//         }

//         public OfertaDTO ObterOfertaPorId(int id)
//         {
//             var ofertaDAO = _ofertaRepository.ObterOfertaPorId(id);
//             return _mapper.Map<OfertaDTO>(ofertaDAO);
//         }

//         public void AdicionarOferta(OfertaDTO oferta)
//         {
//             var ofertaDAO = _mapper.Map<OfertaDAO>(oferta);
//             _ofertaRepository.AdicionarOferta(ofertaDAO);
//         }

//         // Implemente outros métodos do serviço, se necessário
//     }