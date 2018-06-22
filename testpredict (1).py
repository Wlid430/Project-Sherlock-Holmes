import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import time
from sklearn.model_selection import train_test_split
from sklearn.naive_bayes import GaussianNB, BernoulliNB, MultinomialNB
import pickle
import sys

loaded_model=pickle.load(open('C:/Users/WLD/source/repos/UserInterfaceMVC/WebApplication10/Python Reci/model.py', 'rb')) #Model load

data={  
    "sex_cleaned":sys.argv[0],
    "sjMaritalStatusId":sys.argv[1],
    "sjWoonplaatsId":sys.argv[2],
    "itvGoalReached":sys.argv[3],
    "casThemaGebiedId":sys.argv[4],
    "casTargetId":sys.argv[5],
    "proboptId":sys.argv[6]
    }


loaded_model.predict(data)
