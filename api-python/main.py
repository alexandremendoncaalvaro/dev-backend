from fastapi import FastAPI, HTTPException
from pydantic import BaseModel, Field
from typing import List

app = FastAPI()

class PredictRequest(BaseModel):
    numbers: List[float] = Field(..., min_items=1, description="Lista de números para a predição")

@app.post("/predict/")
async def predict(request: PredictRequest):
    if not request.numbers:
        raise HTTPException(status_code=400, detail="A lista de números não pode estar vazia.")

    result = sum(request.numbers)  # Simulação de um modelo ML básico

    return {"prediction": result}
