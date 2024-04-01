
import { ProblemDetails } from './problemDetails';

export interface ValidationProblemDetails extends ProblemDetails {
    errors?: { [key: string]: Array<string>; };
}
