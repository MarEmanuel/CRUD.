export function ConvertDate(fechaOriginal: string): string {
    const fecha = new Date(fechaOriginal);

    const dia = ("0" + fecha.getDate()).slice(-2);
    const mes = ("0" + (fecha.getMonth() + 1)).slice(-2);
    const anio = fecha.getFullYear();

    return `${dia}-${mes}-${anio}`;
}

export function ParseDate(dateString: string): Date | null {
    const [day, month, year] = dateString.split('-').map(Number);

    // Validar que los valores sean correctos
    if (
        !day || !month || !year ||
        month < 1 || month > 12 ||
        day < 1 || day > 31
    ) {
        return null;
    }

    // Crear el objeto Date
    const parsedDate = new Date(year, month - 1, day);

    // Validar que la fecha sea válida
    if (parsedDate.getFullYear() === year &&
        parsedDate.getMonth() === month - 1 &&
        parsedDate.getDate() === day) {
        return parsedDate;
    }

    return null;
}

export function ConvertTime(fechaOriginal: string): string {
    const fecha = new Date(fechaOriginal);

    const horas = ("0" + fecha.getHours()).slice(-2);
    const minutos = ("0" + fecha.getMinutes()).slice(-2);

    return `${horas}:${minutos}`;
}

export function ConvertDateTime(fechaOriginal: string): string {
    // Creamos un objeto Date a partir de la fecha original
    const fecha = new Date(fechaOriginal);

    // Verificamos si la fecha es válida
    if (isNaN(fecha.getTime())) {
        console.error(`Fecha inválida: ${fechaOriginal}`);
        return "Fecha y hora inválidas";
    }

    // Desglosamos la fecha en día, mes, año
    const dia = ("0" + fecha.getDate()).slice(-2);
    const mes = ("0" + (fecha.getMonth() + 1)).slice(-2); // Los meses empiezan desde 0
    const anio = fecha.getFullYear();

    // Desglosamos la hora en horas y minutos
    const horas = ("0" + fecha.getHours()).slice(-2);
    const minutos = ("0" + fecha.getMinutes()).slice(-2);

    // Retornamos la fecha en el formato deseado
    return `${anio}-${mes}-${dia}, ${horas}:${minutos}`;
}