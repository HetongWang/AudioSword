import json
file = open("m01.txt","w")

tune_list = {}
tune_list["l"] = []

for i in xrange(1,10):
	pass
	item = {}
	item["mScore"] = 0
	item["mType"] = 0
	item["mVelocity"] = (1.0 * (i%3) +1)
	item["mDeparture_x"] = (i%3) + 1
	item["mDeparture_y"] = (i%3 + 1) + 1
	item["mDeparture_z"] = (i%3 + 2) + 5
	item["mHitTime"] = item["mVelocity"]*2000 + i*1000
	tune_list["l"].append(item)

file.write(json.dumps(tune_list))
