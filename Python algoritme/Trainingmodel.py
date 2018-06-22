import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import time
from sklearn.model_selection import train_test_split
from sklearn.naive_bayes import GaussianNB, BernoulliNB, MultinomialNB

# Importing dataset
data = pd.read_csv("data/data.csv")

# Convert categorical variable to numeric
data["sex_cleaned"]=np.where(data["sjGender"]=="Male",0,1)


# Cleaning dataset of NaN
data=data[[
    #"sjId",
    "sex_cleaned",
    #"sjDateOfBirth",
    "sjMaritalStatusId",
    "sjWoonplaatsId",
    "itvInterventieOptieId",
    "itvGoalReached",
    "casThemaGebiedId",
    "casTargetId",
    "proboptId",
    #"probProbleemOptieId"
]].dropna(axis=0, how='any')

# Split dataset in training and test datasets
X_train, X_test = train_test_split(data, test_size=0.5, random_state=int(time.time()))

# Instantiate the classifier
gnb = GaussianNB()
used_features =[
    #"sjId",
    "sex_cleaned",
    #"sjDateOfBirth",
    "sjMaritalStatusId",
    "sjWoonplaatsId",
    #"itvInterventieOptieId", #uitkomst
    "itvGoalReached",
    "casThemaGebiedId",
    "casTargetId",
    "proboptId",
    #"probProbleemOptieId"
]

# Train classifier
gnb.fit(
    X_train[used_features].values,
    X_train["sjMari"]
)
y_pred = gnb.predict(X_test[used_features])

# Print results
print("Number of mislabeled points out of a total {} points : {}, performance {:05.2f}%"
      .format(
          X_test.shape[0],
          (X_test["itvInterventieOptieId"] != y_pred).sum(),
          100*(1-(X_test["itvInterventieOptieId"] != y_pred).sum()/X_test.shape[0])
))

# for target_list in y_pred:
#     print("a")

#print (y_pred)



# Importing dataset2
data2 = pd.read_csv("data/testdata.csv")

# Convert categorical variable to numeric
data2["sex_cleaned"]=np.where(data2["sjGender"]=="Male",0,1)


# Cleaning dataset of NaN
data2=data2[[
    "sjId",
    "sex_cleaned",
    #"sjDateOfBirth",
    "sjMaritalStatusId",
    "sjWoonplaatsId",
    "itvInterventieOptieId",
    "itvGoalReached",
    "casThemaGebiedId",
    "casTargetId",
    "proboptId",
    #"probProbleemOptieId"
]].dropna(axis=0, how='any')


testing = gnb.predict(data2[used_features])

# save the model to disk
filename = 'model.sav'
pickle.dump(model, open(filename, 'wb'))

print(testing)