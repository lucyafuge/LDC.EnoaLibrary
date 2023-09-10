using LDC.EnoaLibrary.Classes;
using LDC.EnoaLibrary.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LDC.EnoaLibrary
{
    /// <summary>
    /// Основная библиотека функций
    /// 
    /// Все функции возвращают объект класса Response, где:
    /// ErrorCode - Код ошибки, если ошибки нет - 0
    /// ErrorMessage - Текст ошибки, если ошибки нет - null
    /// Result - Результат работы функции (object)
    /// 
    /// Для инициализации базы знамений используется класс SignContextInitializer,
    /// при необходимости можно передать в конструктор класса экземпляр класса,
    /// унаследованного от SignContextInitializer, с преопределенным методом Initialize,
    /// если необходимо изменить базу знамений
    /// </summary>
    public class EnoaLibrary
    {
        private string ConnectionString { get; set; }
        /// <summary>
        /// Конструктор по умолчанию, в connectionString можно передать путь до файла .bd, если файл не будет найден и isNeedInit true, будет инициализирована новая база знамений
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД</param>
        /// <param name="signContextInitializer">Экземпляр класса инициализации контекста базы, если null - используется инициализация по-умолчанию</param>
        /// <param name="isNeedInit">Нужна ли инициализация базы, по-умолчанию нет</param>
        public EnoaLibrary(string connectionString = "Data Source=signs.db", SignContextInitializer? signContextInitializer = null, bool isNeedInit = false)
        {
            ConnectionString = connectionString;
            if (signContextInitializer == null)
                signContextInitializer = new SignContextInitializer();

            if(isNeedInit)
                signContextInitializer.Initialize(new SignContext(connectionString));
        }

        /// <summary>
        /// Возвращает список знамений в базе
        /// </summary>
        /// <returns>Результат получения списка знамений</returns>
        public Response GetSigns()
        {
            Response response = new Response();
            try
            {
                using (SignContext signContext = new SignContext(ConnectionString))
                {
                    List<Sign> signs = signContext.Signs.ToList();
                    response.Result = signs;
                }
            }
            catch (Exception ex)
            {
                response.ErrorCode = 1;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Возвращает знамение по 4d4
        /// </summary>
        /// <returns>Результат получения списка знамений</returns>
        public Response GetSign(byte Bunti = 0, byte Ayur = 0, byte Dodor = 0, byte Takhar = 0)
        {
            Response response = new Response();
            try
            {
                using (SignContext signContext = new SignContext(ConnectionString))
                {
                    Sign? sign = signContext.Signs.SingleOrDefault(sign => 
                    sign.Bunti == Bunti &&
                    sign.Ayur == Ayur &&
                    sign.Dodor == Dodor &&
                    sign.Takhar == Takhar);

                    if(sign != null)
                        response.Result = sign;
                    else
                    {
                        response.ErrorCode = 2;
                        response.ErrorMessage = $"Не найдено знамение Bunti: {Bunti}, Ayur: {Ayur}, Dodor: {Dodor}, Takhar: {Takhar}";
                    }
                }
                    
            }
            catch (Exception ex)
            {
                response.ErrorCode = 1;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Создает новое знамение
        /// </summary>
        /// <param name="sign">Экземпляр нового знамения</param>
        /// <returns>Результат добавления знамения</returns>
        public Response AddSign(Sign sign)
        {
            Response response = new Response();
            try
            {
                using (SignContext signContext = new SignContext(ConnectionString))
                {
                    signContext.Signs.Add(sign);
                    signContext.SaveChanges();
                    response.Result = sign;
                }
                    
            }
            catch (Exception ex)
            {
                response.ErrorCode = 1;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Изменяет существующее знамение
        /// </summary>
        /// <param name="id">Id изменяемого значения</param>
        /// <param name="sign">Экземпляр изменного знамения</param>
        /// <returns>Результат изменения знамения</returns>
        public Response EditSign(ushort id, Sign sign)
        {
            Response response = new Response();

            return response;
        }

        /// <summary>
        /// Удаляет существуюущее знамение
        /// </summary>
        /// <param name="id">Id удаляемого знамения</param>
        /// <returns>Результат удаления знамения</returns>
        public Response DeleteSign(ushort id)
        {
            Response response = new Response();

            return response;
        }
    }
}